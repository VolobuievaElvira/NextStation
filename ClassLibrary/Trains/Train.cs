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
    [JsonDerivedType(typeof(PassengerTrain), typeDiscriminator: "PassengerTrain")]
    [JsonDerivedType(typeof(FreightTrain), typeDiscriminator: "FreightTrain")]
    public abstract class Train
    {
        [JsonInclude] private static int counter;

        [JsonInclude] private int id;

        [JsonInclude] private string trainCode;
        
        [JsonInclude] private StationName location;

        [JsonInclude] private List<RouteStop> route = new();

        [JsonConstructor]
        public Train(string name, StationName location) 
        {
            id = ++counter;
            trainCode = name;
            this.location = location;
        }

        public int GetId() { return id; }
        public string GetTrainCode() { return trainCode; }

        public void ChangeTrainCode(string trainCode) { this.trainCode = trainCode; } 

        public StationName GetLocation() { return location; }

        public void UpdateLocation(StationName location) { this.location = location; }

        public void AddRouteStop(DateTime arrivalTime, DateTime departureTime, Station station, int platform)
        {
            RouteStop routeStop = new RouteStop(arrivalTime, departureTime, station, platform);
            route.Add(routeStop);
        }

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
        public List<RouteStop> GetAllRouteStop() { return route; }
    }
}
