using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Service.Models
{
    public class MobileServiceContext : DbContext
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

        public MobileServiceContext() : base(connectionStringName)
        {
        }

        public DbSet<AppEvent> AppEvents { get; set; }
        public DbSet<AppFeedback> AppFeedbacks { get; set; }
        public DbSet<AppInsightsEvent> InsightEvents { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<DeviceInfo> Devices { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PerformanceEvent> PerfrPerformanceEvents { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<WeatherCondition> WeatherConditions { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<FlaggedContent> FlaggedContents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

    }
}
