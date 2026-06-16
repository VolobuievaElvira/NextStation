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
    /**
    ** @brief A class that represents a station, including its name, platforms, and timetable
    */
    public class Station
    {
        /// <summary>The id of the last station in the database</summary>
        [JsonInclude] static private int counter = 0;
        /// <summary>The id of the station</summary>

        [JsonInclude] private int id;
        /// <summary>The name of the station</summary>
        [JsonInclude] private StationName name;
        /// <summary>The platforms of the station</summary>
        [JsonInclude] private List<Platform> platforms = new();
        /// <summary>The timetable of the station</summary>
        [JsonInclude] private List<Timetable> timetable = new();

        /**
        ** @brief Initialize a new instance of the Station class
        **
        ** @param name The name of the station
        */
        [JsonConstructor]
        public Station(StationName name)
        {
            id = ++counter;
            this.name = name;
        }

        /**
        ** @brief Returns the station's ID
        **
        ** @return The station's ID
        */
        public int GetId() { return id; }

        /**
        ** @brief Returns the station's name
        **
        ** @return The station's name
        */
        public StationName GetName() { return name; }

        /**
        ** @brief Adds a platform to the station
        **
        ** @param platformNumber The number of the platform to add
        */
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
        /**
        ** @brief Removes a platform from the station by ID
        **
        ** @param id The ID of the platform to remove
        */
        public void RemovePlatformById(int id)
        {
            this.platforms.Remove(GetPlatformById(id));
        }

        /**
        ** @brief Returns the platform with the specified ID
        **
        ** @param id The ID of the platform to retrieve
        ** @return The platform with the specified ID
        */
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
        /**
        ** @brief Returns all platforms at the station
        **
        ** @return The list of platforms at the station
        */
        public List<Platform> GetAllPlatforms() { return this.platforms; }

        /**
        ** @brief Adds a train to the station timetable
        **
        ** @param train The train to add
        ** @param arrivalTime The train's arrival time
        */
        public void AddTrainToTimetable(Train train, DateTime arrivalTime)
        {
            this.timetable.Add(new Timetable(train.GetTrainCode(), arrivalTime));
        }
        /**
        ** @brief not yet implemented
        */
        public void RemoveTrainFromTimetable(Train train, DateTime arrivalTime)
        {

        }

        /**
        ** @brief not yet implemented
        */
        public void UpdateTimetable(Train train, DateTime arrivalTime, float delay)
        {

        }

        /**
        ** @brief Returns the timetable for the station
        **
        ** @return The station's timetable
        */
        public List<Timetable> GetTimetable() { return this.timetable; }
    }
}
