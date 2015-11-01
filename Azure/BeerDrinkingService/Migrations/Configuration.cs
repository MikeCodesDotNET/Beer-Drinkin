using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Service.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.BeerDrinkinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.BeerDrinkinContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.PopularBeerItems.AddOrUpdate(b => b.CountryCode,
                 new PopularBeerItem { CountryCode = "GB", BeerId = "Jc7iGI" },
                 new PopularBeerItem { CountryCode = "GB", BeerId = "vdiLuR" },
                 new PopularBeerItem { CountryCode = "GB", BeerId = "VmBDFZ" },
                 new PopularBeerItem { CountryCode = "GB", BeerId = "z7LxGT" },
                 new PopularBeerItem { CountryCode = "GB", BeerId = "1P45iR" }
                );
        }
    }
}
