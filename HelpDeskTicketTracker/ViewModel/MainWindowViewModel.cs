using HelpDeskTicketTracker.WebServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketTracker.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _incident;
        private string _url;
        private int _request;
        private DateTime _lastUpdated;
        private Tickets _tickets;


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
            this.Incident = 145;
            this.Request = 100;
            this._lastUpdated = DateTime.Now;
            SignalPropertyChanged("LastUpdated");
            this.URL = @"http://localhost:8777";
            _tickets = TicketFactory.CreateTickets();
            _tickets.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                this.Incident = _tickets.incidents;
                this.Request = _tickets.requests;
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void SignalPropertyChanged(string property)
        {
            if (PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
