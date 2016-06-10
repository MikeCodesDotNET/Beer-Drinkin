using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Swagger;
using Swashbuckle.Application;

namespace BeerDrinkin
{
    public partial class Startup
    {
        public static void ConfigureSwagger(HttpConfiguration config)
        {
            // Use the custom ApiExplorer that applies constraints. This prevents
            // duplicate routes on /api and /tables from showing in the Swagger doc.
            config.Services.Replace(typeof(IApiExplorer), new MobileAppApiExplorer(config));
            config
               .EnableSwagger(c =>
               {
                   c.SingleApiVersion("v1", "BeerDrinkin");

               // Tells the Swagger doc that any MobileAppController needs a
               // ZUMO-API-VERSION header with default 2.0.0
               c.OperationFilter<MobileAppHeaderFilter>();

               // Looks at attributes on properties to decide whether they are readOnly.
               // Right now, this only applies to the DatabaseGeneratedAttribute.
               c.SchemaFilter<MobileAppSchemaFilter>();
               })
               .EnableSwaggerUi();
        }
    }
}