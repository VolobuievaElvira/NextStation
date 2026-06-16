using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Net;

namespace ClassLibrary.Trains
{
    public class PassengerTrain : Train
    {
        [JsonInclude] private string photo;
        [JsonInclude] private List<Option> options = new();
        [JsonInclude] private List<Car> cars = new();
        [JsonInclude] private string description = "";

        [JsonConstructor] 
        public PassengerTrain(string trainCode, StationName location, List<Option> options) : base(trainCode, location) 
        {
            options.Sort();
            foreach (Option option in options)
            {
                AddOption(option);
            }
        }

        public void ChangePhoto(string photo) { this.photo = photo; }
        public void AddCar(Car car) 
        {
            if (!car.IsConnected())
            {                
                this.cars.Add(car);
                car.SetTrain(this);
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.CarIsAlreadyConnected, "The car is already connected to a train");
            }
        }
        public void AddOption(Option option)
        {
            if (!options.Contains(option)) options.Add(option);
        }
        public void RemoveCar(Car car)
        {
            if (this.cars.Contains(car))
            {
                car.SetTrain(null);
                this.cars.Remove(car);                
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.CarDoesNotConnected, "The car does not connected to the train");
            }
        }
        public void RemoveOption(Option option)
        {
            if (this.options.Contains(option)) this.options.Remove(option);
        }
        public void ChangeDescription(string description) { this.description = description; }
        public string GetDescription() { return this.description; }
        public string GetPhoto() { return this.photo; }
        public List<Car> GetAllCars() { return this.cars; }
        public List<Option> GetAllOptions() { return this.options; } 
    }
}
