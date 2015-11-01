using System;
using System.IO;

namespace BeerDrinkin.Core.Helpers
{
    public class Gravatar
    {
        public static string CalculateUrl(string email)
        {
            var hash = CalculateMD5Hash(email);

            return string.Format("http://www.gravatar.com/avatar.php?gravatar_id={0}", hash);
        }

        public static string CalculateMD5Hash(string s)
        {
            var md5 = MD5.Create();
            var stream = GenerateStreamFromString(s);

            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(s);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}

