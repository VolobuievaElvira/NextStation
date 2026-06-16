using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using ClassLibrary.Trains;

namespace ClassLibrary
{
    /**
    ** @brief Stores information about a seat on a train, including its number, the carriage it is in, and the ticket associated with it
    */
    public class Seat
    {
        /// <summary>The id of the last seat in the database</summary>
        [JsonInclude] private static int counter = 0;
        /// <summary>The Id of the seat</summary>
        [JsonInclude] private int id;
        /// <summary>The number of the seat in the carriage</summary>
        [JsonInclude] private int number;
        /// <summary>The id of the carriage the seat is in</summary>
        [JsonInclude] private int carId;
        /// <summary>The ticket associated with the seat</summary>
        [JsonInclude] private Ticket ticket;
         /**
        ** @brief Initialize a new instance of the Seat class
        **
        ** @param id The id of the seat
        ** @param number The number of the seat in the carriage
        ** @param carId The id of the carriage the seat is in
        ** @param ticket The ticket associated with the seat
        */
        [JsonConstructor]
        public Seat(int id, int number, int carId, Ticket ticket)
        {
            this.id = id;
            this.number = number;
            this.carId = carId;
            this.ticket = ticket;

            counter = int.Max(counter, id);
        }
        /**
        ** @brief Initialize a new instance of the Seat class
        **
        ** @param number The number of the seat in the carriage
        ** @param car The carriage the seat is in
        */

        public Seat(int number, Car car)
        {
            this.id = ++counter;
            this.number = number;
            this.carId = car.GetId();
            this.ticket = new Ticket(this);
        }
        /**
        ** @brief Gets the number of the seat
        **
        ** @return The number of the seat
        */
        public int GetNumber() { return this.number; }
        /**
        ** @brief Gets the id of the carriage the seat is in
        **
        ** @return The id of the carriage the seat is in
        */
        public int GetCarId() { return this.carId; }
        /**
        ** @brief Gets the ticket associated with the seat
        **
        ** @return The ticket associated with the seat
        */
        public Ticket GetTicket() { return this.ticket; }
    }
}