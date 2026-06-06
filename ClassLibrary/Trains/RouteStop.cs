using ClassLibrary.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    public class RouteStop
    {
        [JsonInclude] static private int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private DateTime arrivalTime; // change
        [JsonInclude] private DateTime departureTime;
        [JsonInclude] private Station station;
        [JsonInclude] private int platform;

        [JsonConstructor]
        public RouteStop(DateTime arrivalTime, DateTime departureTime, Station station, int platform)
        {
            id = ++counter;
            this.arrivalTime = arrivalTime;
            this.departureTime = departureTime;
            this.station = station;
            this.platform = platform;
        }

        public int GetId() { return id; }
        public DateTime GetArrivalDate() { return arrivalTime; }
        public DateTime GetDepartureDate() { return departureTime; }
        public Station GetStation() { return station; }
        public int GetPlatform() { return platform; }
    }
}
