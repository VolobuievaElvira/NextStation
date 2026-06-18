using ClassLibrary.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    /**
    ** @brief Stores information about a stop on a train route, including arrival and departure times, station, and platform
    */
    public class RouteStop
    {
        /// <summary>The id of the last route stop in the database</summary>
        [JsonInclude] private static int counter = 0;
        /// <summary>The id of the route stop</summary>
        [JsonInclude] private int id;
        /// <summary>The time the train arrives at the stop</summary>
        [JsonInclude] private DateTime arrivalTime;
        /// <summary>The time the train departs from the stop</summary>
        [JsonInclude] private DateTime departureTime;
        /// <summary>The station where the train stops</summary>
        [JsonInclude] private Station station;
        /// <summary>The platform where the train stops</summary>
        [JsonInclude] private int platform;
        /**
        ** @brief Initialize a new instance of the RouteStop class
        **
        ** @param arrivalTime The time the train arrives at the stop
        ** @param departureTime The time the train departs from the stop
        ** @param station The station where the train stops
        ** @param platform The platform where the train stops
        */
        [JsonConstructor]
        
        public RouteStop(DateTime arrivalTime, DateTime departureTime, Station station, int platform)
        {

            id = ++counter;
            this.arrivalTime = arrivalTime;
            this.departureTime = departureTime;
            this.station = station;
            this.platform = platform;
        }
        /**
        ** @brief Gets the id of the route stop
        **
        ** @return The id of the route stop
        */
        public int GetId() { return id; }
        /**
        ** @brief Gets the arrival time of the route stop
        **
        ** @return The arrival time of the route stop
        */
        public DateTime GetArrivalDate() { return arrivalTime; }
        /**
        ** @brief Gets the departure time of the route stop
        **
        ** @return The departure time of the route stop
        */
        public DateTime GetDepartureDate() { return departureTime; }
        /**
        ** @brief Gets the station of the route stop
        **
        ** @return The station of the route stop
        */
        public Station GetStation() { return station; }
        /**
        ** @brief Gets the platform of the route stop
        **
        ** @return The platform of the route stop
        */
        public int GetPlatform() { return platform; }
    }
}
