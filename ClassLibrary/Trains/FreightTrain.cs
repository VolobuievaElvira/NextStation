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
        [JsonConstructor] 
        public FreightTrain(string trainCode, StationName location, int capacity) : base(trainCode, location) { }

    }        
}
