using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Stations
{
    public class Timetable
    {
        [JsonInclude] private string trainCode;

        [JsonInclude] DateTime arrivalTime;
        [JsonInclude] float delay;

        [JsonConstructor]
        public Timetable(string trainCode, DateTime arrivalTime, float delay = 0)
        {
            this.trainCode = trainCode;
            this.arrivalTime = arrivalTime;
            this.delay = delay;
        }

        public string GetTrainCode() { return this.trainCode; }
        public DateTime GetArrivalTime() { return this.arrivalTime; }
        public float GetDelay() { return this.delay; }
        public void UpdateDelay(float delay)
        {
            this.delay = delay;
        }
    }
}
