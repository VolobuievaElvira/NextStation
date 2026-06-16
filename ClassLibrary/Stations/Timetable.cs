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
        /// <summary>The train code for the timetable</summary>
        [JsonInclude] private string trainCode;
        /// <summary>The arrival time for the timetable</summary>
        [JsonInclude] private DateTime arrivalTime;
        /// <summary>The delay for the timetable</summary>
        [JsonInclude] private float delay;

        /**
        ** @brief Initialize a new instance of the Timetable class
        **
        ** @param trainCode The code of the train
        ** @param arrivalTime The arrival time of the train
        ** @param delay The delay for the train
        */
        [JsonConstructor]
        public Timetable(string trainCode, DateTime arrivalTime, float delay = 0)
        {
            this.trainCode = trainCode;
            this.arrivalTime = arrivalTime;
            this.delay = delay;
        }

        /**
        ** @brief Returns the train code for the timetable
        **
        ** @return The train code
        */
        public string GetTrainCode() { return this.trainCode; }

        /**
        ** @brief Returns the arrival time for the timetable
        **
        ** @return The arrival time
        */
        public DateTime GetArrivalTime() { return this.arrivalTime; }

        /**
        ** @brief Returns the delay for the timetable
        **
        ** @return The delay
        */
        public float GetDelay() { return this.delay; }

        /**
        ** @brief Updates the delay for the timetable
        **
        ** @param delay The new delay value
        */
        public void UpdateDelay(float delay)
        {
            this.delay = delay;
        }
    }
}
