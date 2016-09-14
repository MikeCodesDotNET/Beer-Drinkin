using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Owin;
using Swashbuckle.Application;
using System.Data.Entity.Migrations;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

//using BeerDrinin.Service.Migrations;
//using BeerDrinkin.Service.Migrations;

namespace BeerDrinkin.Service
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.EnableSwagger(c => c.SingleApiVersion("v1", "Beer Drinkin API").Contact(cc => cc.Name("Mike James").Url("http://mikecodes.net").Email("mijam@microsoft.com"))).EnableSwaggerUi();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.MapHttpAttributeRoutes();


            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);
            
            // Use Entity Framework Code First to create database tables based on your DbContext
            //var migratior = new DbMigrator(new BeerDrinin.Service.Migrations.Configuration());
            //migratior.Update();

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["AppInsightsApiKey"];

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            base.Seed(context);
        }
    }
}

