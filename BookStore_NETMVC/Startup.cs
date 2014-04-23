using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStore_NETMVC.Startup))]
namespace BookStore_NETMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
