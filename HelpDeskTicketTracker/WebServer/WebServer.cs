using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskTicketTracker.WebServer
{
    public class Server
    {
        IDisposable _server;
        public Server()
        {
            string baseAddress = "http://localhost:8777/";

            //start OWIN host
            _server = WebApp.Start<Startup>(url: baseAddress);

        }
    }

    class Startup
    {
        //This code configurs web api.  The startup class is specified as a type
        //parameter in the webapp.start method
        public void Configuration(IAppBuilder appBuilder)
        {
            //configure web api for self host
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //disable xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            appBuilder.UseWebApi(config);

            //configure file server
            FileServerOptions config2 = new FileServerOptions();
            config2.FileSystem = new PhysicalFileSystem(@"./WebServer/View");
            config2.EnableDirectoryBrowsing = true;

            appBuilder.UseFileServer(config2);
        }
    }
}
