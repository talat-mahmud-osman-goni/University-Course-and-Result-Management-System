using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityResultManagement.Startup))]
namespace UniversityResultManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
