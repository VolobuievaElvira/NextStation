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
    /**
    ** @brief Manages the program's database, stores and loads users, cars, trains, and stations to/from JSON database
    */
    public class DataBase
    {
        /// <summary>Users present in the database</summary>
        List<User> users = new List<User>();

        /// <summary>Cars present in the database</summary>
        List<Car> cars = new List<Car>();

        /// <summary>Trains present in the database</summary>
        List<Train> trains = new List<Train>();

        /// <summary>Stations present in the database</summary>
        List<Station> stations = new List<Station>();

        /// <summary>Path to the users JSON database files</summary>
        private string users_path;

        /// <summary>Path to the cars JSON database files</summary>
        private string cars_path;

        /// <summary>Path to the trains JSON database files</summary>
        private string trains_path;

        /// <summary>Path to the stations JSON database files</summary>
        private string stations_path;

        /**
        ** @brief Creates a new PassengerTrain object and stores it in the database
        **
        ** @param trainCode The train's code
        ** @param location The train's location
        ** @param options The train's options
        **
        ** @return nothing
        */
        public void AddPassengerTrain(string trainCode, StationName location, List<Option> options) 
        {
            PassengerTrain train = new PassengerTrain(trainCode, location, options);
            trains.Add(train);
            SaveData();
        }

        /**
        ** @brief Creates a new FreightTrain object and stores it in the database
        **
        ** @param trainCode The train's code
        ** @param location The train's location
        ** @param capacity The train's capacity
        **
        ** @return nothing
        */

        public void AddFreightTrain(string trainCode, StationName location, float capacity)
        {
            FreightTrain train = new FreightTrain(trainCode, location, capacity);
            trains.Add(train);
            SaveData();
        }

        /**
        ** @brief Romove the train from the database
        **
        ** @param train The train that needs to be removed
        **
        ** @return nothing
        */
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

        /**
        ** @brief Creates a new Car object and stores it in the database
        **
        ** @param seatsNumber The number of seats
        ** @param carClass The car's class
        **
        ** @return nothing
        */
        public void AddCar(int seatsNumber, CarClass carClass)
        {
            Car car = new Car(seatsNumber, carClass);
            this.cars.Add(car);
        }

        /**
        ** @brief Removes the car by its ID from the database
        **
        ** @param id The car's ID that needs to be removed
        **
        ** @return nothing
        */
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

        /**
        ** @brief Creates a new Passenger object and stores it in the database
        **
        ** @param name The passenger's name
        ** @param email The passenger's email
        ** @param password The passenger's password
        ** @param photo The passenger's photo
        **
        ** @return nothing
        */
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

        /**
        ** @brief Creates a new Staff object and stores it in the database
        **
        ** @param role The staff's role
        ** @param name The staff's name
        ** @param email The staff's email
        ** @param password The staff's password
        ** @param photo The staff's photo
        **
        ** @return nothing
        */
        public void AddStaff(Role role, string name, string email, string password, string photo = "")
        {
            if (!(users.FirstOrDefault(u => u.GetEmail() == email, null) is null)) throw new RegisterError(RegisterErrorReason.EmailAlreadyRegistered, "The email is alredy registered. Try to login");
            User user = new Staff(name, email, password, photo, role);
            if (!(user is null))
            {
                users.Add(user);
                SaveData();
            }
        }

        /**
        ** @brief Removes the user from the database
        **
        ** @param user The user that needs to be removed
        **
        ** @return nothing
        */
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

        /**
        ** @brief Search for specific users in the database
        **
        ** @param id The user's ID
        ** @param name The user's name
        ** @param email The user's email
        **
        ** @return A list of users whose data matches the search parameters
        */
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

        /**
        ** @brief Search for specific station in the database
        **
        ** @param station The station's name
        **
        ** @return A station whose name matches the search parameter
        */
        public Station? StationSearch(StationName station)
        {
            return this.stations.FirstOrDefault(s => (s.GetName() == station), null);
        }

        /**
        ** @brief Search for specific cars in the database
        **
        ** @param id The car's ID
        ** @param carClass The car's class
        **
        ** @return A list of cars whose data matches the search parameters
        */
        public List<Car> CarSearch(int? id = null, CarClass? carClass = null)
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

        /**
        ** @brief Search for specific trains in the database
        **
        ** @param trainCode The train's code
        ** @param departureStation The train's departure station
        ** @param arrivalStation The train's arrival station
        ** @param departureDate The train's departure date
        ** @param arrivalDate The train's arrival date
        ** @param routeType The train's route type
        ** @param options The train's options
        **
        ** @return A list of trains whose data matches the search parameters
        */
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

        /**
        ** @brief Initialize a new instance of the DataBase class. Stores paths to the JSON database files
        **
        ** @param users_path Path to the users JSON database files
        ** @param cars_path Path to the cars JSON database files
        ** @param trains_path Path to the trains JSON database files
        ** @param stations_path Path to the stations JSON database files
        **
        */
        public DataBase(string users_path, string cars_path, string trains_path, string stations_path)
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

        /**
        ** @brief Saves users, cars, trains, and stations to the JSON databases
        **
        ** @return nothing
        */
        public void SaveData()
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
