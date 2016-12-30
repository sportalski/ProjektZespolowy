using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProj.Startup))]
namespace MVCProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
