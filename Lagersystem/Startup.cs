using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lagersystem.Startup))]
namespace Lagersystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
