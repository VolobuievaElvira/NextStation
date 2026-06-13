using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ClassLibrary.Trains
{
    public class Car
    {
        [JsonInclude] static private int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private PassengerTrain? train;
        [JsonInclude] private List<Seat> seats = new();
        [JsonInclude] private CarClass carClass; //change name

        [JsonConstructor]
        public Car(int seatsNumber, CarClass carClass) //change name
        {
            id = ++counter;
            this.seats = Enumerable.Range(1, seatsNumber)
                       .Select(x => new Seat(x, this))
                       .ToList();
            this.carClass = carClass;
        }
        public int GetId() { return this.id; }
        public PassengerTrain? GetTrain() { return this.train; }
        public bool IsConnected() { return this.train is null; }
        public List<Seat> GetAllSeats() { return this.seats; }
        public CarClass GetClass() { return this.carClass; }
    }
}
