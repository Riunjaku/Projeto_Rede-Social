using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BatataSocial.Startup))]
namespace BatataSocial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
