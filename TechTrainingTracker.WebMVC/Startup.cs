using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechTrainingTracker.WebMVC.Startup))]
namespace TechTrainingTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
