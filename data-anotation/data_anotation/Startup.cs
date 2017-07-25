using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(data_anotation.Startup))]
namespace data_anotation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
