using ClassLibrary.Trains;

namespace NextStation
{
    public class Saver
    {
        List<Train> filteredTrains = new();

        public void SaveFilteredTrains(List<Train> filteredTrains)
        {
            this.filteredTrains = filteredTrains;
        }
        public List<Train> ReturnFilteredTrains()
        {
            return filteredTrains;
        }
    }
}
