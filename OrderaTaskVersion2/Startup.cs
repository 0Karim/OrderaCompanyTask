using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderaTaskVersion2.Startup))]
namespace OrderaTaskVersion2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
