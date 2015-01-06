using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Client.Startup))]
namespace Web.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
