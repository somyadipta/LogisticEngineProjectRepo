using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogisticEngine.Startup))]
namespace LogisticEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
