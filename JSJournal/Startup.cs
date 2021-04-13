using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSJournal.Startup))]
namespace JSJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
