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

        public void BookTicket(Ticket ticket)
        {
            if (ticket.IsAvaible())
            {
                ticket.SetPassenger(this);
                this.tickets.Add(ticket);
            }
            else
            {
                throw new BookingError(BookingErrorReason.TicketIsAlreadyBooked, "The ticket is already booked");
            }
        }

        [JsonConstructor] 
        public Passenger(string name, string email, string password, string photo) : base(name, email, password, photo) { }
    }
}
