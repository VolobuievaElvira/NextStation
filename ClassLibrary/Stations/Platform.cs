using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Stations
{
    public class Platform
    {
        [JsonInclude] private static int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private int number;

        [JsonInclude] private List<TimeInterval> occupiedIntervals = new();

        [JsonConstructor]
        public Platform(int number)
        {
            this.id = ++counter;
            this.number = number;
        }

        public int GetId() { return this.id; }
        public int GetNumber() { return this.number; }
        public bool AreOverlaps(DateTime arrivalTime, DateTime departureTime)
        {
            List<TimeInterval> overlaps = this.occupiedIntervals
                .Where(oi => oi.GetStartTime() >= arrivalTime && oi.GetEndTime() <= departureTime)
                .ToList();
            return overlaps.Count() != 0;
        }
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
