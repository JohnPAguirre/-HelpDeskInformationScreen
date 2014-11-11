using HelpDeskTicketTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketTracker.ViewModel
{
    public class MainWindowViewModel : IMainWindow
    {
        private int _incident;
        private string _url;
        private int _request;
        private DateTime _lastUpdated;


        public int Incident
        {
            get
            {
                return _incident;
            }
            set
            {
                _incident = value;
                SignalPropertyChanged("Incident");
            }
        }

        public int Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
                SignalPropertyChanged("Request");
            }
        }

        public string LastUpdated
        {
            get
            {
                return "Last Updated: " + _lastUpdated.ToLocalTime().ToString("R");
            }
            set
            {
                _lastUpdated = DateTime.Parse(value);
                _lastUpdated = DateTime.SpecifyKind(_lastUpdated, DateTimeKind.Utc);
                SignalPropertyChanged("LastUpdated");
            }
        }

        public string URL
        {
            get
            {
                return "Please visit " + _url + " to update this screen";
            }
            set
            {
                _url = value;
                SignalPropertyChanged("URL");
            }
        }

        public MainWindowViewModel()
        {
            this.Incident = 110;
            this.Request = 100;
            this._lastUpdated = DateTime.Now;
            SignalPropertyChanged("LastUpdated");
            this.URL = @"http://172.0.0.1:8080";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void SignalPropertyChanged(string property)
        {
            if (PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
