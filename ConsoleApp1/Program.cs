using ClassLibrary;
using ClassLibrary.Data;

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

            dataBase.AddStaff(Role.NetworkManager, "Admin", "admin@gamil.com", "Admin@123");

            dataBase.SaveData();
            //Console.WriteLine(dataBase.trains.Count.ToString());
            //Console.WriteLine(dataBase.TrainSearch(null, null, null, null, null, null, null).Count.ToString());
        }
    }
}
