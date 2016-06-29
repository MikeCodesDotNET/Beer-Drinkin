using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin
{
    public class BeerDrinkinContext : DbContext
    {
        private const string CONNECTION_STRING_NAME = "Name=MS_TableConnectionString";

        static BeerDrinkinContext()
        {
            // Automatic migration
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeerDrinkinContext, Migrations.Configuration>());

            Database.SetInitializer<BeerDrinkinContext>(new CreateDatabaseIfNotExists<BeerDrinkinContext>());

            // No migration
            //Database.SetInitializer<BeerDrinkinContext>(null);
        }

        public BeerDrinkinContext() : base(CONNECTION_STRING_NAME)
        { }


        public DbSet<User> Users { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<AppEvent> AppEvents { get; set; }
        public DbSet<CheckInEnvironmentalCondition> CheckInEnvironmentalConditions { get; set; }
    }
}
