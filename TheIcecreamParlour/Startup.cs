using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheIcecreamParlour.Startup))]
namespace TheIcecreamParlour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
