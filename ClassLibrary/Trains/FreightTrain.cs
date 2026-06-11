using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    public class FreightTrain : Train
    {

        [JsonInclude] private float capacity;

        [JsonConstructor] 
        public FreightTrain(string trainCode, StationName location, int capacity) : base(trainCode, location) 
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
        public float GetCapacity() { return this.capacity; }
        public void ChangeCapacity(float capacity) { this.capacity = capacity; }
    }        
}
