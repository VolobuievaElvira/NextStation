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
        [JsonInclude] private Passenger? passenger;
        [JsonInclude] private Seat seat;

        public Ticket(Seat seat)
        {
            this.id = ++counter;
            this.seat = seat;
        }
        public int GetId() { return id; }
        public Passenger? GetPassenger() { return passenger; }

        public void SetPassenger(Passenger passenger) { this.passenger = passenger; } //Add!!!
        public Seat GetSeat() { return seat; }
        public bool IsAvaible() { return passenger is null; }
    }
}
