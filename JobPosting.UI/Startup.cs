using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPosting.UI.Startup))]
namespace JobPosting.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
