using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementClient.Startup))]
namespace ManagementClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
