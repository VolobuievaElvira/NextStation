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
        [JsonInclude] private int carId;
        [JsonInclude] private Ticket ticket;

        [JsonConstructor]
        public Seat(int id, int number, int carId, Ticket ticket)
        {
            this.id = id;
            this.number = number;
            this.carId = carId;
            this.ticket = ticket;

            counter = int.Max(counter, id);
        }
        public Seat(int number, Car car)
        {
            this.id = ++counter;
            this.number = number;
            this.carId = car.GetId();
            this.ticket = new Ticket(this);
        }

        public int GetNumber() { return this.number; }
        public int GetCarId() { return this.carId; }
        public Ticket GetTicket() { return this.ticket; }
    }
}