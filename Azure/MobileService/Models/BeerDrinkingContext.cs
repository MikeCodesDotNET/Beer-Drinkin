using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using BeerDrinkin.Service.DataObjects;
using Microsoft.Azure.Mobile.Server.Tables;

namespace BeerDrinkin.Service.Models
{
    public class BeerDrinkinContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public BeerDrinkinContext() : base(connectionStringName)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Style> BeerStyles { get; set; }
        public DbSet<Available> Availablity { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Images> Imageses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SocailMedia> SocalMedia { get; set; }

        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<FollowerItem> FollowerItems { get; set; }
        public DbSet<CheckInItem> CheckInItems { get; set; }
        public DbSet<BinaryItem> BinaryItems { get; set; }
        public DbSet<ReviewItem> ReviewItems { get; set; }
        public DbSet<UserPrivateData> UserPrivateItems { get; set; }
        public DbSet<PopularBeerItem> PopularBeerItems { get; set; }
        public DbSet<AccountItem> AccountItems { get; set; }
        public DbSet<KeywordSpellingCorrection> KeywordCorrections { get; set; }
        public DbSet<SearchEventItem> SearchEvents { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
        */

    }

}
