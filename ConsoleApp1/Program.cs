using ClassLibrary;
using ClassLibrary.Data;
using ClassLibrary.Trains;
using ClassLibrary.Users;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MainSystem mainSystem = new();

            DataBase dataBase = new("users.json", "cars.json", "trains.json", "stations.json");
            //dataBase.AddPassengerTrain("tre3", StationName.Bolzano, new List<Option>());
            //dataBase.AddPassenger("anna","anna@abc","Anna1234!");

            //dataBase.AddStaff(Role.NetworkManager, "Admin", "admin@gamil.com", "Admin@123");

            //dataBase.Add
            //dataBase.AddPassengerTrain("Pas-Trento-Bolzano", StationName.Brenner, new List<Option>());
            //dataBase.AddCar(20, CarClass.FirstClass);
            //dataBase.AddCar(40, CarClass.SecondClass);
            //dataBase.AddCar(50, CarClass.FirstClass);
            //dataBase.AddCar(60, CarClass.SecondClass);
            //dataBase.AddCar(70, CarClass.FirstClass);
            //dataBase.AddCar(80, CarClass.SecondClass);

            List<Car> cars = dataBase.CarSearch();
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.GetId()} {car.GetClass().ToString()}");
            }

            try
            {

                List<Train> trains = dataBase.TrainSearch(null, null, null, null, null, null, new List<Option>());


                Console.WriteLine("--start--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain3)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");
                        foreach (Car car in passengerTrain3.GetAllCars())
                        {
                            Console.WriteLine($"\t{car.GetId()}");
                        }
                    }
                }

                Console.WriteLine("--start--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain2)
                    {
                        Console.WriteLine($"{train.GetTrainCode()} - here");
                        foreach (Car car in passengerTrain2.GetAllCars())
                        {
                            Console.WriteLine($"\t{car.GetId()} - now in");
  
                        }
                    }
                }
                Console.WriteLine("--remove2--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain3)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");

                        List<Car> toRemove = passengerTrain3.GetAllCars().ToList();
                        foreach (Car car in toRemove)
                        {
                            Console.WriteLine($"\t{car.GetId()} - before remove");
                            passengerTrain3.RemoveCar(car);
                        }
                    }
                }

                Console.WriteLine("--after remove2--");

                Console.WriteLine("--add--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain2)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");
                        foreach (Car car in cars)
                        {
                            //if (car != null)
                            //{
                            Console.WriteLine($"\t{car.GetId()} - add");
                            passengerTrain2.AddCar(car);
                            // dataBase.SaveData();
                            //}
                        }
                    }
                    Console.WriteLine(train.GetTrainCode());
                }


                Console.WriteLine("--add--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain3)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");
                        foreach (Car car in passengerTrain3.GetAllCars())
                        {
                            Console.WriteLine($"\t{car.GetId()}");
                        }
                    }
                }

                Console.WriteLine("--remove--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain3)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");

                        List<Car> toRemove = passengerTrain3.GetAllCars().ToList();
                        foreach (Car car in toRemove)
                        {
                            passengerTrain3.RemoveCar(car);
                        }
                    }
                }

                Console.WriteLine("--after remove--");

                foreach (Train train in trains)
                {
                    if (train is PassengerTrain passengerTrain3)
                    {
                        Console.WriteLine($"{train.GetTrainCode()}");
                        foreach (Car car in passengerTrain3.GetAllCars())
                        {
                            Console.WriteLine($"\t{car.GetId()}");
                        }
                    }
                }

                dataBase.SaveData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            
            //Console.WriteLine(dataBase.trains.Count.ToString());
            //Console.WriteLine(dataBase.TrainSeacrh(null, null, null, null, null, null, null).Count.ToString());
        }
    }
}
