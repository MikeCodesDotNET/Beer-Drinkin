using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerDrinkin.Service.Services
{
    public class SpellCorrectionService
    {
        public string CorrectSpelling(string searchTerm)
        {
            var spellingCorrector = new Helpers.Spelling();
            var suggestedSpelling = spellingCorrector.Correct(searchTerm);

            return suggestedSpelling;
        }
    }
}