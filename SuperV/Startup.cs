using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperV.Startup))]
namespace SuperV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
