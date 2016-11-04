using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Drawer.Startup))]
namespace Drawer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
