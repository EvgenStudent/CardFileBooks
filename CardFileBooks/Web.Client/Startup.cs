using Microsoft.Owin;
using Owin;
using Web.Client;

[assembly: OwinStartup(typeof (Startup))]

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