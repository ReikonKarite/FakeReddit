using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeReddit.Startup))]
namespace FakeReddit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
