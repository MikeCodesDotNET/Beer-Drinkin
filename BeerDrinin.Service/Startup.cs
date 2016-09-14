using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BeerDrinkin.Service.Startup))]

namespace BeerDrinkin.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}