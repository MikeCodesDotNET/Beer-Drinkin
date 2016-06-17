using System.Configuration;
using Microsoft.Azure.Mobile.Server.Tables;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Models
{
    public class BeerDrinkinContext : DbContext
    {
        private const string CONNECTION_STRING_NAME = "Name=MS_TableConnectionString";

        static BeerDrinkinContext()
        {
            // Automatic migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeerDrinkinContext, Migrations.Configuration>());

            //Database.SetInitializer<BeerDrinkinContext>(new DropCreateDatabaseAlways<BeerDrinkinContext>());

            // No migration
            //Database.SetInitializer<BeerDrinkinContext>(null);
        }

        public BeerDrinkinContext() 
            : base(CONNECTION_STRING_NAME)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        
    }
}
