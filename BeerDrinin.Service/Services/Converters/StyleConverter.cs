using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Converters
{
    public class StyleConverter
    {
        public async Task<Style> Convert(BreweryDB.Interfaces.IStyle dbStyle)
        {
            if (dbStyle == null)
                return null;

            var style = new Style
            {
                Name = dbStyle.Name,
                ShortName = dbStyle.ShortName,
                Description = dbStyle.Description,
                IbuMin = dbStyle.IbuMin,
                IbuMax = dbStyle.IbuMax,
                AbvMin = dbStyle.AbvMin,
                AbvMax = dbStyle.AbvMax,
                SrmMin = dbStyle.SrmMin,
                SrmMax = dbStyle.SrmMax,
                OgMin = dbStyle.OgMin,
                FgMax = dbStyle.FgMax,
                FgMin = dbStyle.FgMin
            };
            return style;
        }

    }
}
