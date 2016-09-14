using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BreweryDB.Converter
{
    public class StyleConverter
    {
        private string apiKey;
        public StyleConverter(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<Style> ConvertStyleById(string id)
        {
            var client = new BreweryDbClient(apiKey);
            var styleResponse = await client.Styles.Get(id);
            var dbStyle = styleResponse.Data;

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
