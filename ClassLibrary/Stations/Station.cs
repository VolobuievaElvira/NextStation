using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using ClassLibrary.Trains;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace ClassLibrary.Stations
{
    public class Station
    {
        [JsonInclude] static private int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private StationName name;
        [JsonInclude] private List<Platform> platforms = new();
        [JsonInclude] private List<Timetable> timetable = new();

        [JsonConstructor]
        public Station(StationName name)
        {
            id = ++counter;
            this.name = name;
        }

        public int GetId() { return id; }

        public StationName GetName() { return name; }

        public void AddPlatform(int platformNumber)
        {
            Platform? platform = this.platforms.FirstOrDefault(p => p.GetNumber() == platformNumber, null);
            if (platform == null) {
                this.platforms.Add(new Platform(platformNumber));
            }
            else
            {
                throw new StationManagementError(StationManagementErrorReason.PlatformAlreadyExists, "The platform with the same number already exists");
            }
        }
        public void RemovePlatformById(int id)
        {
            this.platforms.Remove(GetPlatformById(id));
        }
        public Platform GetPlatformById(int id)
        {
            Platform? platform = this.platforms.FirstOrDefault(p => p.GetId() == id, null);
            if (platform == null)
            {
                throw new StationManagementError(StationManagementErrorReason.PlatformDoesNotExist, "The platform with this id does not exist");
            }
            else
            {
                return platform;
            }
        } 
        public List<Platform> GetAllPlatforms() { return this.platforms; }
        public void AddTrainToTimetable(Train train, DateTime arrivalTime)
        {
            this.timetable.Add(new Timetable(train.GetTrainCode(), arrivalTime));
        }
        public void RemoveTrainFromTimetable(Train train, DateTime arrivalTime)
        {

        }
        public void UpdateTimetable(Train train, DateTime arrivalTime, float delay)
        {

        }
        public List<Timetable> GetTimetable() { return this.timetable; }
    }
}
