using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMock.Startup))]
namespace MVCMock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
