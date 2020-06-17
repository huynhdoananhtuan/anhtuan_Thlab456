using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenDuyNam_lab456.Startup))]
namespace NguyenDuyNam_lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
