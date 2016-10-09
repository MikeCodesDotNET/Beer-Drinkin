using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Models;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Services.Mock
{
	public class SearchService : ISearchService
	{
		readonly IAzureClient azure;
		public SearchService()
		{
			azure = ServiceLocator.Instance.Resolve<IAzureClient>();
		}

		public Task<List<Beer>> Search(string searchTerm)
		{
			var duvel = new Beer
			{
				Name = "Duvel",
				Description = "Duvel is a natural beer with a subtle bitterness, a refined flavour and a distinctive hop character. The unique brewing process, which takes about 90 days, guarantees a pure character, delicate effervescence and a pleasant sweet taste of alcohol.\n\nApart from pure spring water, which is the main ingredient of beer, barley is the most important raw material. Barley must germinate for five days in the malt house, after which malt remains. The colour of the malt and as a consequence also of the beer is determined by the temperature. Duvel obtains its typical bitterness by adding various varieties of aromatic Slovenian and Czech hops. We use only exclusive hops that are renowned for their constant, outstanding quality.\n\nDuvel ferments for the first time in tanks at 20 to 26°C. The brewer uses his own culture for this. The original yeast strain, which Victor Moortgat himself selected in the 1920’s, originates from Scotland. After maturing in storage tanks in which the beer is cooled down to -2°C, the drink is ready for bottling. Thanks to the addition of extra sugars and yeast, the beer ferments again in the bottle. This occurs in warm cellars (24°C) and takes two weeks. Then the beer is moved to cold cellars, where it continues to mature and stabilise for a further six weeks. This extra long maturation period is unique and contributes to the refined flavour and pure taste of Duvel.\n\nA team of beer specialists checks the process daily by means of taste analyses. It is only after 90 days, when it has achieved its rich range of flavours, that Duvel may leave the brewery.\n\nThanks to its surprisingly high alcohol content (8.5 %), enormous head, fine effervescence and silky smooth feel in the mouth, Duvel stands out clearly from other Belgian beers.",
				BreweryId = "KSqbyz",
				OriginCountry = "Belgium",
				Abv = 8.5,
				BreweryDbId = "c8VKLu",
				RateBeerId = "1434"
			};

			var response = new List<BeerDrinkin.Models.Beer>();
			response.Add(duvel);
			return Task.FromResult(response);
		}
	}
}
