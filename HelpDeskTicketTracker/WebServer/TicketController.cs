using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskTicketTracker.WebServer
{
    public class TicketController : ApiController
    {
        
        public Tickets Get()
        {
            return TicketFactory.CreateTickets();
        }

        public void Post([FromBody]Tickets fromURL)
        {
            var internalStore = TicketFactory.CreateTickets();
            internalStore.incidents = fromURL.incidents;
            internalStore.requests = fromURL.requests;
        }
    }

    public class TicketFactory
    {
        private static Tickets _lifetimeTickets;

        public static Tickets CreateTickets()
        {
            if (_lifetimeTickets == null)
            {
                _lifetimeTickets = new Tickets()
                {
                    requests = 50,
                    incidents = 75
                };
            }

            return _lifetimeTickets;
        }
    }

    public class Tickets : INotifyPropertyChanged
    {
        private int _requests;
        private int _incidents;

        public int requests
        {
            get
            {
                return _requests;
            }
            set
            {
                _requests = value;
                SignalPropertyChagned("requests");
            }
        }
        public int incidents
        {
            get
            {
                return _incidents;
            }
            set
            {
                _incidents = value;
                SignalPropertyChagned("incidents");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void SignalPropertyChagned(string propertyName){
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
