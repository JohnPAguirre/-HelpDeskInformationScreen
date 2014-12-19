using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HelpDeskTicketTracker.WebServer;

namespace HelpDeskTicketTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Server _webServer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _webServer = new Server();
        }
    }
}
