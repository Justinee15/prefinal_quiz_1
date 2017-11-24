using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PREFINAL_QUIZ1.Startup))]
namespace PREFINAL_QUIZ1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
