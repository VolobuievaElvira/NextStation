using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Stations
{
    public class TimeInterval
    {
        [JsonInclude] DateTime startTime;
        [JsonInclude] DateTime endTime;

        [JsonConstructor]
        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public DateTime GetStartTime() { return this.startTime; }
        public DateTime GetEndTime() { return this.endTime; }
    }
}
