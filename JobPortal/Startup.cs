using Microsoft.Owin;
using Owin;
using DAL.Controller;

[assembly: OwinStartup(typeof(JobPortal.Startup))]
namespace JobPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            StartupData.AddstartupData();
        }
    }
}
