using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Service.Migrations
{
    using DataObjects;
    using Microsoft.Azure.Mobile.Server.Tables;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerDrinkinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }

        protected override void Seed(BeerDrinkinContext context)
        {
            if (context.Beers.Find("00000000-0000-0000-0000-000000000001") == null)
            {
                context.Beers.Add(
                    new Beer
                    {
                        BreweryDbId = "Jc7iGI",
                        Name = "Stella Artois",
                        Description = "Stella Artois was first brewed as a Christmas beer in leuven. It was named Stella from the star of Christmas, and Artois after Sebastian Artois, founder of the brewery. It's brewed to perfection using the original Stella Artois yeast and the celebrated Saaz hops. It's the optimum premium lager, with it's full flavour and clean crisp taste.",
                        BreweryId = "mIWMKP",
                        StyleId = "75",
                        Abv = 5.2,
                        ImageSmall = "https://s3.amazonaws.com/brewerydbapi/beer/Jc7iGI/upload_80NL4b-icon.png",
                        ImageMedium = "https://s3.amazonaws.com/brewerydbapi/beer/Jc7iGI/upload_80NL4b-medium.png",
                        ImageLarge = "https://s3.amazonaws.com/brewerydbapi/beer/Jc7iGI/upload_80NL4b-large.png",
                        CreatedAt = DateTimeOffset.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
