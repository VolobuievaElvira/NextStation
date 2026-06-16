using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Stations
{
    /**
    ** @brief Stores information about a platform at a station, including its number and occupied time intervals
    */
    public class Platform
    {
        /// <summary>The id of the last platform in the database</summary>
        [JsonInclude] private static int counter = 0;
        /// <summary>The id of the platform</summary>
        [JsonInclude] private int id;
        /// <summary>The number of the platform</summary>
        [JsonInclude] private int number;
        /// <summary>The list of occupied time intervals for the platform</summary>
        [JsonInclude] private List<TimeInterval> occupiedIntervals = new();
        /**
        ** @brief Initialize a new instance of the Platform class
        **
        ** @param number The number of the platform
        */
        [JsonConstructor]
        public Platform(int number)
        {
            this.id = ++counter;
            this.number = number;
        }
        /**
        ** @brief Gets the id of the platform
        **
        ** @return The id of the platform
        */
        public int GetId() { return this.id; }
        /**
        ** @brief Gets the number of the platform
        **
        ** @return The number of the platform
        */
        public int GetNumber() { return this.number; }
        /**
        ** @brief Checks if the given time interval overlaps with any existing intervals
        **
        ** @param arrivalTime The arrival time
        ** @param departureTime The departure time
        ** @return True if it overlaps an existing interval, otherwise false
        */
        public bool AreOverlaps(DateTime arrivalTime, DateTime departureTime)
        {
            List<TimeInterval> overlaps = this.occupiedIntervals
                .Where(oi => oi.GetStartTime() >= arrivalTime && oi.GetEndTime() <= departureTime)
                .ToList();
            return overlaps.Count() != 0;
        }
        /**
        ** @brief Adds a new occupied time interval for the platform
        **
        ** @param arrivalTime The arrival time
        ** @param departureTime The departure time
        */
        public void AddOccupiedInterval(DateTime arrivalTime, DateTime departureTime)
        {
            if (AreOverlaps(arrivalTime, departureTime))
            {
                throw new StationManagementError(StationManagementErrorReason.OverlapOccured, "Failed, an overlap occured");
            }
            else
            {
                this.occupiedIntervals.Add(new TimeInterval(arrivalTime, departureTime));
            }
        }
        /**
        ** @brief Removes an occupied time interval for the platform
        **
        ** @param arrivalTime The arrival time
        ** @param departureTime The departure time
        */
        public void RemoveOccupiedInterval(DateTime arrivalTime, DateTime departureTime)
        {
            TimeInterval? interval = this.occupiedIntervals
                .FirstOrDefault(oi => oi.GetStartTime() == arrivalTime && oi.GetEndTime() == departureTime, null);
            if (interval == null)
            {
                throw new StationManagementError(StationManagementErrorReason.TimeIntervalDoesNotExist, "The time interval does not exist");
            }
            else
            {
                this.occupiedIntervals.Remove(interval);
            }
        }
    }
}
