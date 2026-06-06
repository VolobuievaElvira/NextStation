using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Stations
{
    public class Station
    {
        [JsonInclude] static private int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private StationName name;
        [JsonInclude] private List<Platform> platforms;
        [JsonInclude] private List<Timetable> timetable;

        [JsonConstructor]
        public Station(StationName name)
        {
            id = ++counter;
            this.name = name;
        }

        public int GetId() { return id; }

        public StationName GetName() { return name; }
    }
}
