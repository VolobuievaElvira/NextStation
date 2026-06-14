using ClassLibrary.Trains;

namespace NextStation
{
    public class Saver
    {
        private List<Train> filteredTrains = new();
        private Train? train = null;

        public void SaveTrain(Train train)
        {
            this.train = train;
        }
        public Train ReturnTrain()
        {
            return this.train;
        }


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
