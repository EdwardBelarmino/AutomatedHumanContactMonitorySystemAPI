using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutomatedHumanContactMonitorySystemAPI.Startup))]
namespace AutomatedHumanContactMonitorySystemAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
