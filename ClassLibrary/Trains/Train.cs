using ClassLibrary.Stations;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Trains
{
    /**
    ** @brief An abstract class that represents a train, including its train code, location, and route stops
    */
    [JsonDerivedType(typeof(PassengerTrain), typeDiscriminator: "PassengerTrain")]
    [JsonDerivedType(typeof(FreightTrain), typeDiscriminator: "FreightTrain")]
    public abstract class Train
    {
        /// <summary>The id of the last train in the database</summary>
        [JsonInclude] private static int counter;
        /// <summary>The id of the train</summary>
        [JsonInclude] private int id;
        /// <summary>The code of the train</summary>
        [JsonInclude] private string trainCode;
        /// <summary>The location of the train</summary>
        [JsonInclude] private StationName location;
        /// <summary>The route stops of the train</summary>

        [JsonInclude] private List<RouteStop> route = new();
        /**
        ** @brief Initialize a new instance of the Train class
        **
        ** @param name The name of the traain
        ** @param location The location of the train
        */

        [JsonConstructor]
        public Train(string name, StationName location) 
        {
            id = ++counter;
            trainCode = name;
            this.location = location;
        }
        /**
        ** @brief Gets the id of the train
        **
        ** @return The id of the train
        */
        public int GetId() { return id; }
        /**
        ** @brief Gets the train code of the train
        **
        ** @return The train code of the train
        */
        public string GetTrainCode() { return trainCode; }
        /**
        ** @brief changes the train code of the train
        **
        ** @param trainCode The new train code of the train
        */

        public void ChangeTrainCode(string trainCode) { this.trainCode = trainCode; } 
        /**
        ** @brief Gets the location of the train
        **
        ** @return The location of the train
        */

        public StationName GetLocation() { return location; }
        /**
        ** @brief Updates the location of the train
        **
        ** @param location The new location of the train
        */
        public void UpdateLocation(StationName location) { this.location = location; }
        /**
        ** @brief Adds a new route stop to the train's route
        **
        ** @param arrivalTime The arrival time of the route stop
        ** @param departureTime The departure time of the route stop
        ** @param station The station of the route stop
        ** @param platform The platform of the route stop
        */

        public void AddRouteStop(DateTime arrivalTime, DateTime departureTime, Station station, int platform)
        {
            RouteStop routeStop = new RouteStop(arrivalTime, departureTime, station, platform);
            route.Add(routeStop);
        }

        /**
        ** @brief Removes a route stop from the train's route by its id 
        **
        ** @param id The id of the route stop to be removed
        */


        public void RemoveRouteStopById(int id)
        {
            RouteStop? routeStop = route.FirstOrDefault(r => r.GetId() == id, null);
            if (routeStop is not null && this.route.Contains(routeStop))
            {
                this.route.Remove(routeStop);
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.RouteStopDoesNotExists, "The route stop does not present in the train's route");
            }
        }
        /**
        ** @brief Gets all the route stops of the train
        **
        ** @return A list of all the route stops of the train
        */
        public List<RouteStop> GetAllRouteStop() { return route; }
    }
}
