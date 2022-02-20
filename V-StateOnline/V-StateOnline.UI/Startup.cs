using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(V_StateOnline.UI.Startup))]
namespace V_StateOnline.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
