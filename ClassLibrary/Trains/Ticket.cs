using ClassLibrary.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    /**
    ** @brief Stores information about a ticket for a train ride, including the passenger, seat, and travel details
    */
    public class Ticket
    {
        /// <summary>The id of the last Ticket in the database</summary>
        [JsonInclude] private static int counter = 0;
        /// <summary>The Id of the ticket</summary>
        [JsonInclude] private int id;
        /// <summary>The id of the passenger associated with the ticket</summary>
        [JsonInclude] private int? passengerId = null;
        /// <summary>The number of the seat associated with the ticket</summary>
        [JsonInclude] private int seatNumber;
        /**
        ** @brief Initialize a new instance of the Ticket class
        **
        ** @param id The id of the ticket
        ** @param passengerId The id of the passenger associated with the ticket
        ** @param seatNumber The number of the seat associated with the ticket
        */

        [JsonConstructor]
        public Ticket(int id, int? passengerId, int seatNumber)
        {
            this.id = id;
            this.passengerId = passengerId;
            this.seatNumber = seatNumber;

            counter = int.Max(counter, id);
        }
        /**
        ** @brief Initialize a new instance of the Ticket class
        **
        ** @param seat The seat associated with the ticket

        */

        public Ticket(Seat seat)
        {
            this.id = ++counter;
            this.seatNumber = seat.GetNumber();
        }
        /**
        ** @brief Returns the ticket's ID
        **
        ** @return The ticket's ID
        */
        public int GetId() { return id; }
        /**
        ** @brief Returns the id of the passenger associated with the ticket
        **        
        ** @return The id of the passenger associated with the ticket
        */
        public int? GetPassengerId() { return this.passengerId; }
        /**
        ** @brief Sets the passenger associated with the ticket
        **        
        ** @param passenger The passenger to associate with the ticket
        */

        public void SetPassenger(Passenger passenger) { this.passengerId = passenger.GetId(); } //Add!!!
        /**
        ** @brief Returns the number of the seat associated with the ticket
        **        
        ** @return The number of the seat associated with the ticket
        */
        public int GetSeatNumber() { return this.seatNumber; }
        /**
        ** @brief Checks if the ticket is available (i.e., not associated with a passenger)
        **
        ** @return True if the ticket is available, otherwise false
        */
        public bool IsAvaible() { return passengerId is null; }
    }
}
