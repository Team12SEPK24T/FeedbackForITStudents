using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeedbackForITStudents.Startup))]
namespace FeedbackForITStudents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
