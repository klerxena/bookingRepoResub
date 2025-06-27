using BookingCommon;

namespace BookingDL
{
    public class BookingDataStore
    {
        //static IAppointmentRepository appointmentRepository = new  InMemoryAppointmentRepository();
        //static IAppointmentRepository appointmentRepository = new JsonFileAppointmentRepository();
        //static IAppointmentRepository appointmentRepository = new TextFileAppointmentRepository();
        static IAppointmentRepository appointmentRepository = new DataBaseAppointmentRepository();

        public void Add(string name, string birthday, string date)
        {
            appointmentRepository.Add(name, birthday, date);
        }

        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public List<Appointment> Search(string name)
        {
            return appointmentRepository.Search(name);
        }

        public bool Delete(string name)
        {
            return appointmentRepository.Delete(name);
        }

        public bool Update(string name, string newDate)
        {
            return appointmentRepository.Update(name, newDate);
        }

        public bool Retrieve(string name)
        {
            return appointmentRepository.Retrieve(name);
        }


    }
}
