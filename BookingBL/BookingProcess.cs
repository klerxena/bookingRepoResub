using BookingCommon;
using BookingDL;

namespace BookingBL
{
    public class BookingProcess
    {
        BookingDataStore dataStore = new BookingDataStore();

        public void Add(string name, string birthday, string date)
        {
            dataStore.Add(name, birthday, date);
        }

        public List<Appointment> GetAll()
        {
            return dataStore.GetAll();
        }

        public List<Appointment> Search(string name)
        {
            return dataStore.Search(name);
        }

        public bool Delete(string name)
        {
            return dataStore.Delete(name); 
        }

        public bool Update(string name, string newDate)
        {
            return dataStore.Update(name, newDate);
        }

        public bool Retrieve(string name)
        {
            return dataStore.Retrieve(name);
        }
    }
}
