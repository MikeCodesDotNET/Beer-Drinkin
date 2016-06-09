using System;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BeerDrinkin.Startup))]

namespace BeerDrinkin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // HACK: for Azure web apps,
            // the try-catch block lets us see errors that occur during configuration
            try
            {
                ConfigureMobileApp(app);
            }
            catch (Exception ex)
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync(ex.ToString());
                });
            }

            // Run on each request
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hooray. It didn't error out.");
            });
        }


    }
}