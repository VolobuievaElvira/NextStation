using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    public class PassengerTrain : Train
    {
        [JsonInclude] private string photo;
        [JsonInclude] private List<Option> options = new();
        [JsonInclude] private List<Car> cars = new();
        [JsonInclude] private string description = "";

        [JsonConstructor] 
        public PassengerTrain(string trainCode, StationName location) : base(trainCode, location) { }
        public void AddOption(Option option)
        {
            if (!options.Contains(option)) options.Add(option);
        }

        public void RemoveOption(Option option)
        {
            if (options.Contains(option)) options.Remove(option);
        }
    }
}
