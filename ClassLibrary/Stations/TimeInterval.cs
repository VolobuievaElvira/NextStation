using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Stations
{
    /**
    ** @brief Stores a time interval that has a start and end time.
    */
    public class TimeInterval
    {
        /// <summary>Stores the start time of the interval</summary>
        [JsonInclude] DateTime startTime;
        
        /// <summary>Stores the end time of the interval</summary>
        [JsonInclude] DateTime endTime;
        
        /**
        ** @brief Initialize a new instance of the TimeInterval class
        **
        ** @param startTime The start time of the interval
        ** @param endTime The end time of the interval
        */

        [JsonConstructor]
        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }
       
        /**
        ** @brief Gets the start time of the interval
        **
        ** @return The start time of the interval
        */
        public DateTime GetStartTime() { return this.startTime; }
       

        /**
        ** @brief Gets the end time of the interval
        **
        ** @return The end time of the interval
        */
        public DateTime GetEndTime() { return this.endTime; }
        
    }
}
