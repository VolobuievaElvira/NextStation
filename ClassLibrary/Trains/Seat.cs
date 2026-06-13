using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using ClassLibrary.Trains;

namespace ClassLibrary
{
    public class Seat
    {
        [JsonInclude] private static int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private int number;
        [JsonInclude] private Car car;
        [JsonInclude] private Ticket ticket;

        [JsonConstructor]
        public Seat(int number, Car car)
        {
            this.id = ++counter;
            this.number = number;
            this.car = car;
            this.ticket = new Ticket(this);
        }

        public int GetNumber() { return this.number; }
        public Car GetCar() { return this.car; }
        public Ticket GetTicket() { return this.ticket; }
    }
}