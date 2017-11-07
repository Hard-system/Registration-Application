using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(ACCDataStore.Web.Startup))]
namespace ACCDataStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);

            
        }
    }
}
