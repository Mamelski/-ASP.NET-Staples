using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Staples.Startup))]
namespace Staples
{
    using System.IO;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
           // TODO kind of ugly
            var dataPath = @"c:\temp\mamelski\";
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
        }
    }
}
