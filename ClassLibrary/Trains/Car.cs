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
        [JsonInclude] private int? trainId;
        [JsonInclude] private List<Seat> seats = new();
        [JsonInclude] private CarClass carClass;

        [JsonConstructor]
        public Car(int id, CarClass carClass, int? trainId, List<Seat> seats)
        {
            this.id = id;
            this.carClass = carClass;
            this.trainId = trainId;
            this.seats = seats;

            counter = int.Max(counter, id); 
        }
        public Car(int seatsNumber, CarClass carClass)
        {
            if (seatsNumber <= 0) throw new TrainManagementError(TrainManagementErrorReason.NumberOfSeatsLessOrEqualZero, "The number of seats must be greater than zero");

            id = ++counter;
            this.seats = Enumerable.Range(1, seatsNumber)
                       .Select(x => new Seat(x, this))
                       .ToList();
            this.carClass = carClass;
        }
        public int GetId() { return this.id; }
        public int? GetTrainId() { return this.trainId; }
        public bool IsConnected() { return this.trainId is not null; }

        public void SetTrain(PassengerTrain? train) { this.trainId = train is not null ? train.GetId() : null; }
        public List<Seat> GetAllSeats() { return this.seats; }
        public CarClass GetClass() { return this.carClass; }
    }
}
