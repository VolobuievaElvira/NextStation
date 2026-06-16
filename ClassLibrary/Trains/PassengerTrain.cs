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
    /**
    ** @brief A class that represents a passenger train, including its photo, options, cars, and description
    */
    public class PassengerTrain : Train
    {
        /// <summary>The photo of the passenger train</summary>
        [JsonInclude] private string photo;
        /// <summary>The options of the passenger train</summary>
        [JsonInclude] private List<Option> options = new();
        /// <summary>The carriages of the passenger train</summary>
        [JsonInclude] private List<Car> cars = new();
        /// <summary>The description of the passenger train</summary>
        [JsonInclude] private string description = "";
        /**
        ** @brief Initialize a new instance of the PassengerTrain class
        **
        ** @param trainCode The code of the passenger train
        ** @param location The location of the passenger train
        ** @param options The options of the passenger train
        */

        [JsonConstructor] 
        public PassengerTrain(string trainCode, StationName location, List<Option> options) : base(trainCode, location) 
        {
            options.Sort();
            foreach (Option option in options)
            {
                AddOption(option);
            }
        }
        /**
        ** @brief Changes the photo of the passenger train
        **
        ** @param photo The new photo of the passenger train
        */

        public void ChangePhoto(string photo) { this.photo = photo; }
        /**
        ** @brief Adds a carriage to the passenger train
        **
        ** @param car The carriage to be added to the passenger train
        */
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
        /**
        ** @brief Adds an option to the pasenger train
        **
        ** @param option The opton to be added to the passenger train
        */
        public void AddOption(Option option)
        {
            if (!options.Contains(option)) options.Add(option);
        }
        /**
        ** @brief Removes a carriage from the passenger train
        **
        ** @param car The carriage to be removed from the passenger train
        */
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
        /**
        ** @brief Removes an option from the passenger train
        **
        ** @param option The option to be removed from the passenger train
        */
        public void RemoveOption(Option option)
        {
            if (this.options.Contains(option)) this.options.Remove(option);
        }
        /**
        ** @brief Changes the description of the passenger train
        **
        ** @param description The new description of the passenger train
        */
        public void ChangeDescription(string description) { this.description = description; }
        /**
        ** @brief Gets the description of the passenger train
        **
        ** @return The description of the passenger train
        */
        public string GetDescription() { return this.description; }
        /**
        ** @brief Gets the photo of the passenger train
        **
        ** @return The photo of the passenger train
        */
        public string GetPhoto() { return this.photo; }
        /**
        ** @brief Gets all the carriages of the passenger train
        **
        ** @return A list of all the carriages of the passenger train
        */
        public List<Car> GetAllCars() { return this.cars; }
        /**
        ** @brief Gets all the options of the passenger train
        **
        ** @return A list of all the options of the passenger train
        */
        public List<Option> GetAllOptions() { return this.options; } 
    }
}
