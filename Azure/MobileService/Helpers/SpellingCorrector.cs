using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeerDrinkin.Service.Helpers
{
        /// <summary>
        /// Conversion from http://norvig.com/spell-correct.html by C.Small
        /// </summary>
        public class Spelling
        {
            private Models.BeerDrinkinContext context = new Models.BeerDrinkinContext();
            private Dictionary<String, int> _dictionary = new Dictionary<String, int>();
            private static Regex _wordRegex = new Regex("[a-z]+", RegexOptions.Compiled);

            public Spelling()
            {
                List<string> wordList = context.BeerItems.Select(x => x.Name).ToList();
                foreach (var word in wordList)
                {
                    string trimmedWord = word.Trim().ToLower();
                    if (_wordRegex.IsMatch(trimmedWord))
                    {
                        if (_dictionary.ContainsKey(trimmedWord))
                            _dictionary[trimmedWord]++;
                        else
                            _dictionary.Add(trimmedWord, 1);
                    }
                }
            }

            public string Correct(string word)
            {
                if (string.IsNullOrEmpty(word))
                    return word;

                word = word.ToLower();

                // known()
                if (_dictionary.ContainsKey(word))
                    return word;

                List<String> list = Edits(word);
                Dictionary<string, int> candidates = new Dictionary<string, int>();

                foreach (string wordVariation in list)
                {
                    if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                        candidates.Add(wordVariation, _dictionary[wordVariation]);
                }

                if (candidates.Count > 0)
                    return candidates.OrderByDescending(x => x.Value).First().Key;

                // known_edits2()
                foreach (string item in list)
                {
                    foreach (string wordVariation in Edits(item))
                    {
                        if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                            candidates.Add(wordVariation, _dictionary[wordVariation]);
                    }
                }

                return (candidates.Count > 0) ? candidates.OrderByDescending(x => x.Value).First().Key : word;
            }

            private List<string> Edits(string word)
            {
                var splits = new List<Tuple<string, string>>();
                var transposes = new List<string>();
                var deletes = new List<string>();
                var replaces = new List<string>();
                var inserts = new List<string>();

                // Splits
                for (int i = 0; i < word.Length; i++)
                {
                    var tuple = new Tuple<string, string>(word.Substring(0, i), word.Substring(i));
                    splits.Add(tuple);
                }

                // Deletes
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (!string.IsNullOrEmpty(b))
                    {
                        deletes.Add(a + b.Substring(1));
                    }
                }

                // Transposes
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (b.Length > 1)
                    {
                        transposes.Add(a + b[1] + b[0] + b.Substring(2));
                    }
                }

                // Replaces
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (!string.IsNullOrEmpty(b))
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            replaces.Add(a + c + b.Substring(1));
                        }
                    }
                }

                // Inserts
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        inserts.Add(a + c + b);
                    }
                }

                return deletes.Union(transposes).Union(replaces).Union(inserts).ToList();
            }
        }
    }
