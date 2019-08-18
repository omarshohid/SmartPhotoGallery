using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(READ.Startup))]
namespace READ
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
