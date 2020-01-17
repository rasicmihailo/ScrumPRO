using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScrumPRO.Startup))]
namespace ScrumPRO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
