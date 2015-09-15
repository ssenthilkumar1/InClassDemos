using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRestaurant_Website.Startup))]
namespace eRestaurant_Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
