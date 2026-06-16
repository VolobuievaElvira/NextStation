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
    public class Ticket
    {
        [JsonInclude] private static int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private int? passengerId = null;
        [JsonInclude] private int seatNumber;

        public Ticket(Seat seat)
        {
            this.id = ++counter;
            this.seatNumber = seat.GetNumber();
        }
        public int GetId() { return id; }
        public int? GetPassengerId() { return this.passengerId; }

        public void SetPassenger(Passenger passenger) { this.passengerId = passenger.GetId(); } //Add!!!
        public int GetSeatNumber() { return this.seatNumber; }
        public bool IsAvaible() { return passengerId is null; }
    }
}
