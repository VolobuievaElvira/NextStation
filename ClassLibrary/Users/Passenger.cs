using ClassLibrary.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Users
{
    /**
    ** @brief Stores passenger tickets, allows passenger to book a ticket and view all booked tickets
    */
    public class Passenger : User
    {
        /// <summary>Tickets booked by the passenger</summary>
        [JsonInclude] private List<Ticket> tickets = new List<Ticket>();

        /**
        ** @brief Returns tickets booked by the passenger
        **
        ** @return Tickets booked by the passenger
        */
        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        /**
        ** @brief Charges the passenger for the ticket, adds it to the passenger's booked tickets, and sets the ticket owner (passenger) for the passenger
        **
        ** @param ticket Selected ticket for booking
        */
        public void BookTicket(Ticket ticket)
        {
            if (ticket.IsAvailable())
            {
                ticket.SetPassenger(this);
                this.tickets.Add(ticket);
            }
            else
            {
                throw new BookingError(BookingErrorReason.TicketIsAlreadyBooked, "The ticket is already booked");
            }
        }

        /**
        ** @brief Initialize a new instance of the Passenger class
        **
        ** @param name The passenger's name
        ** @param email The passenger's email
        ** @param password The passenger's password
        ** @param photo The passenger's photo
        */
        [JsonConstructor] 
        public Passenger(string name, string email, string password, string photo) : base(name, email, password, photo) { }
    }
}
