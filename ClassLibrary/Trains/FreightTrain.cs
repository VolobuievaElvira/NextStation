using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
     /**
    ** @brief Stores information about a freight train, including its train code, location, and cargo capacity
    */
    public class FreightTrain : Train
    {
        /// <summary>The cargo capacity of the freight train</summary>
        [JsonInclude] private float capacity;

        /**
        ** @brief Initialize a new instance of the FreightTrain class
        **
        ** @param trainCode The code of the freight train
        ** @param location The location of the freight train
        ** @param capacity The cargo capacity of the freight train
        */
        [JsonConstructor] 
        public FreightTrain(string trainCode, StationName location, float capacity) : base(trainCode, location) 
        {
            if (capacity > 0)
            {
                this.capacity = capacity;
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.CapacityLessOrEqualZero, "The capacity must be greater than zero");
            }
        }
        /**
        ** @brief Gets the carriage capacity of the freight train
        **
        ** @return The carriage capacity of the freight train
        */
        public float GetCapacity() { return this.capacity; }
        /**
        ** @brief Gets the number of the platform
        **
        ** @param capacity The new carriage capacity of the freight train
        */
        public void ChangeCapacity(float capacity) { this.capacity = capacity; }
    }        
}
