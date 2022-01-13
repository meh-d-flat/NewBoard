using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewBoard.Startup))]
namespace NewBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
