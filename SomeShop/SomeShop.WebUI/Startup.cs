using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SomeShop.WebUI.Startup))]
namespace SomeShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
