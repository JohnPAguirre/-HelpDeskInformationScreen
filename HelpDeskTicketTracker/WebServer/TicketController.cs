using System;
using System.Collections.Generic;
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
            return new Tickets()
            {
                request = 10,
                incidents = 50
            };
        }
    }

    public class Tickets
    {
        public int request;
        public int incidents;

    }
}
