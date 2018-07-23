using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MIS.Backend.Startup))]

namespace MIS.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}