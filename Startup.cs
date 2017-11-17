using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_BĐS.Startup))]
namespace Website_BĐS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
