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
    /**
    ** @brief Stores information about a carriage, including its ID, class, and associated train.
    */
    public class Car
    {
        /// <summary>The id of the last Car in the database</summary>
        [JsonInclude] static private int counter = 0;
        /// <summary>The id of the Car</summary>
        [JsonInclude] private int id;
        /// <summary>The id of the train the Carriage is associated with</summary>
        [JsonInclude] private int? trainId;
        /// <summary>The seats in the Carriage</summary>
        [JsonInclude] private List<Seat> seats = new();
        /// <summary>The class of the Carriage</summary>
        [JsonInclude] private CarClass carClass;
        /**
        ** @brief Initialize a new instance of the Car class
        **
        ** @param id The id of the carriage
        ** @param carClass The class of the carriage
        ** @param trainId The id of the train the carriage is associated with
        ** @param seats The seats in the carriage
        */

        [JsonConstructor]
        public Car(int id, CarClass carClass, int? trainId, List<Seat> seats)
        {
            this.id = id;
            this.carClass = carClass;
            this.trainId = trainId;
            this.seats = seats;

            counter = int.Max(counter, id); 
        }
        /**
        ** @brief Initialize a new instance of the Car class
        **
        ** @param seatsNumber The number of seats in the carriage
        ** @param carClass The class of the carriages
        */
        public Car(int seatsNumber, CarClass carClass)
        {
            if (seatsNumber <= 0) throw new TrainManagementError(TrainManagementErrorReason.NumberOfSeatsLessOrEqualZero, "The number of seats must be greater than zero");

            id = ++counter;
            this.seats = Enumerable.Range(1, seatsNumber)
                       .Select(x => new Seat(x, this))
                       .ToList();
            this.carClass = carClass;
        }
        /**
        ** @brief Returns the carriage's ID
        **
        ** @return The carriage's ID
        */
        public int GetId() { return this.id; }
        /**
        ** @brief Returns the id of the train the carriage is associated with
        **
        ** @return The id of the train the carriage is associated with
        */
        public int? GetTrainId() { return this.trainId; }
        /**
        ** @brief Returns whether the carriage is associated with a train
        **
        ** @return True if the carriage is associated with a train, false otherwise
        */
        public bool IsConnected() { return this.trainId is not null; }
        /**
        ** @brief Sets the train associated with the carriage
        **
        ** @param train The train to associate with the carriage
        */

        public void SetTrain(PassengerTrain? train) { this.trainId = train is not null ? train.GetId() : null; }
        /**
        ** @brief Gets all the seats in the carriage
        **
        ** @return A list of all the seats in the carriage
        */
        public List<Seat> GetAllSeats() { return this.seats; }
        /**
        ** @brief Gets the class of the carriage
        **
        ** @return The class of the carriage
        */
        public CarClass GetClass() { return this.carClass; }
    }
}
