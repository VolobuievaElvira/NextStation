using ClassLibrary.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Users
{
    public class Passenger : User
    {
        [JsonInclude] private List<Ticket> tickets = new List<Ticket>();

        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        public void BookTicket()
        {
            throw new Exception("Book a ticket");
        }

        [JsonConstructor] 
        public Passenger(string name, string email, string password, string photo) : base(name, email, password, photo) { }
    }
}
