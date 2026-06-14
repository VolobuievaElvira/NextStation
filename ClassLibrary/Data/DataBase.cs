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
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
            PassengerTrain train = new PassengerTrain(trainCode, location, options);
            trains.Add(train);
            SaveData();
        }

        public void AddFreightTrain(string trainCode, StationName location, float capacity)
        {
            FreightTrain train = new FreightTrain(trainCode, location, capacity);
            trains.Add(train);
            SaveData();
        }

        public void RemoveTrain(Train train)
        {
            if (this.trains.Contains(train))
            {
                this.trains.Remove(train);
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.TrainDoesNotExists, "The train does not present in the DataBase");
            }
        }

        public void AddCar(int seatsNumber, CarClass carClass)
        {
            Car car = new Car(seatsNumber, carClass);
            this.cars.Add(car);
        }

        public void RemoveCarById(int id)
        {
            Car? car = this.cars.FirstOrDefault(c => c.GetId() == id, null);
            if (car is null)
            {
                this.cars.Remove(car);
            }
            else
            {
                throw new TrainManagementError(TrainManagementErrorReason.CarDoesNotExists, "The car does not present in the DataBase");
            }
        }
        public void AddPassenger(string name, string email, string password, string photo="")
        {
            if (!(users.FirstOrDefault(u => u.GetEmail() == email, null) is null)) throw new RegisterError(RegisterErrorReason.EmailAlreadyRegistered, "The email is alredy registered. Try to login");
            User user = new Passenger(name, email, password, photo);
            if (!(user is null))
            {
                users.Add(user);
                SaveData();
            }
        }

        public void AddStaff(Role role, string name, string email, string password, string photo = "")//change order
        {
            if (!(users.FirstOrDefault(u => u.GetEmail() == email, null) is null)) throw new RegisterError(RegisterErrorReason.EmailAlreadyRegistered, "The email is alredy registered. Try to login");
            User user = new Staff(name, email, password, photo, role);
            if (!(user is null))
            {
                users.Add(user);
                SaveData();
            }
        }

        public void RemoveUser(User user)
        {
            if (this.users.Contains(user))
            {
                this.users.Remove(user);
            }
            else
            {
                throw new UserManagementError(UserManagementErrorReason.UserDoesNotExists, "The user does not present in the DataBase");
            }
        }

        public List<User> UserSearch(int? id = null, string? name = null, string? email = null)
        {
            List<User> users = this.users;

            if (id != null)
            {
                users = users.Where(u => u.GetId() == id).ToList();
            }
            if (email != null)
            {
                users = users.Where(u => u.GetEmail() == email).ToList();
            }
            if (name != null)
            {
                users = users.Where(u => u.GetName() == name).ToList();
            }         
           
            return users;
        }

        public Station? StationSearch(StationName station) //change
        {
            return this.stations.FirstOrDefault(s => (s.GetName() == station), null);
        }

        public List<Car> CarSearch(int? id = null, CarClass? carClass = null) //change a bit names
        {
            List<Car> cars = new();
            if (id != null)
            {
                cars = cars.Where(c => c.GetId() == id).ToList();
            }
            if (carClass != null)
            {
                cars = cars.Where(c => c.GetClass() == carClass).ToList();
            }
            return cars;
        }
        public List<Train> TrainSeacrh(string? trainCode, StationName? departureStation, StationName? arrivalStation, DateTime? departureDate, DateTime? arrivalDate, RouteType? routeType, List<Option>? options)
        {
            List<Train> trains = this.trains;

            trains = trains.Where
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

            if(options.Count > 0)
            {
                trains = trains.Where
                    (
                        t => t is PassengerTrain passengerTrain
                        &&
                        options.All(op => passengerTrain.GetAllOptions().Contains(op))
                    ).ToList();
            }
            return trains;
        }

        public DataBase(string users_path, string cars_path, string trains_path, string stations_path)//Add
        {
            this.users_path = users_path;
            this.cars_path = cars_path;
            this.trains_path = trains_path;
            this.stations_path = stations_path;

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
