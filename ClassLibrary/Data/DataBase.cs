using ClassLibrary.Stations;
using ClassLibrary.Trains;
using ClassLibrary.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using System.IO;

namespace ClassLibrary.Data
{
    public class DataBase
    {
        List<User> users = new List<User>();
        List<Car> cars = new List<Car>();
        List<Train> trains = new List<Train>();
        List<Station> stations = new List<Station>();

        private string users_path, cars_path, trains_path, stations_path;//Add

        public void AddPassengerTrain(string trainCode, StationName location, List<Option> options) 
        {
            PassengerTrain train = new PassengerTrain(trainCode, location);
            foreach (Option option in options)
            {
                train.AddOption(option);
            }
            trains.Add(train);
            SaveData();
        }
        //skip

        public void AddPassenger(string name, string email, string password, string photo="")
        {
            if (!Equals(users.FirstOrDefault(u => u.GetEmail() == email, null), null)) throw new RegisterError(RegisterErrorReason.EmailAlreadyRegistered, "The email is alredy registered. Try to login");
            User user = new Passenger(name, email, password, photo);
            if (!Equals(user, null))
            {
                users.Add(user);
                SaveData();
            }
        }

        public List<User> GetUsers() { return users; } //!!! add to the class diagram
        
        public List<Train> TrainSeacrh(string? trainCode, StationName? departureStation, StationName? arrivalStation, DateTime? departureDate, DateTime? arrivalDate, RouteType? routeType, List<Option>? options)
        {
            return trains
                .Where
                (
                    t =>
                        (
                            t.GetTrainCode() == trainCode || trainCode == null
                        )
                        &&
                        (
                            t.GetAllRouteStop()
                            .Any
                            (
                                s => s.GetStation().GetName() == departureStation
                            ) || departureStation == null
                        )
                        &&
                        (
                            t.GetAllRouteStop()
                            .Any
                            (
                                s => s.GetStation().GetName() == arrivalStation
                            ) || arrivalStation == null
                        )
                        &&
                        (
                            t.GetAllRouteStop()
                            .Any
                            (
                                s => s.GetDepartureDate() >= departureDate
                            ) || departureDate == null
                        )
                        &&
                        (
                            t.GetAllRouteStop()
                            .Any
                            (
                                s => s.GetArrivalDate() <= arrivalDate
                            ) || arrivalDate == null
                        )

                ).ToList();
        }

        public DataBase(string users_path, string cars_path, string trains_path, string stations_path)//Add
        {
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            this.users_path = users_path;//Path.Combine(baseDirectory, users_path); 
            this.cars_path = cars_path;// Path.Combine(baseDirectory, cars_path);
            this.trains_path = trains_path;//Path.Combine(baseDirectory, trains_path);
            this.stations_path = stations_path;// Path.Combine(baseDirectory, stations_path);

            try
            {
                if (File.Exists(this.users_path))
                {
                    string json_users = File.ReadAllText(this.users_path);
                    this.users = JsonSerializer.Deserialize<List<User>>(json_users);
                }
                if (File.Exists(this.cars_path))
                {
                    string json_cars = File.ReadAllText(this.cars_path);
                    this.cars = JsonSerializer.Deserialize<List<Car>>(json_cars);
                }
                if (File.Exists(this.trains_path))
                {
                    string json_trains = File.ReadAllText(this.trains_path);
                    this.trains = JsonSerializer.Deserialize<List<Train>>(json_trains);
                }
                if (File.Exists(this.cars_path))
                {
                    string json_stations = File.ReadAllText(this.stations_path);
                    this.stations = JsonSerializer.Deserialize<List<Station>>(json_stations);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("smth went wrong "+e.Message);
            }
        }

        public void SaveData()//Add
        {
            string json_users = JsonSerializer.Serialize(this.users);
            File.WriteAllText(users_path, json_users);

            string json_cars = JsonSerializer.Serialize(this.cars);
            File.WriteAllText(cars_path, json_cars);

            string json_trains = JsonSerializer.Serialize(this.trains);
            File.WriteAllText(trains_path, json_trains);

            string json_stations = JsonSerializer.Serialize(this.stations);
            File.WriteAllText(stations_path, json_stations);
        }
    }
}
