using HelpDeskTicketTracker.ViewModel;
using HelpDeskTicketTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketTracker.IOC
{
    class ViewModelFactory
    {
        private static MainWindowViewModel _mainWindow;

        public static MainWindowViewModel NewMainWindowViewModel
        {
            get
            {
                if (_mainWindow == null)
                    _mainWindow = new MainWindowViewModel();
                return _mainWindow;
            }
        }
    }
}
