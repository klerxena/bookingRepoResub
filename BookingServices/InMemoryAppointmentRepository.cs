using BookingCommon;

namespace BookingDL
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        List<Appointment> appointments = new List<Appointment>();
        List<Appointment> deletedAppointments = new List<Appointment>();

        public List<Appointment> GetAll()
        {
            return appointments;
        }

        public void Add(string name, string birthday, string date)
        {
            var appointment = new Appointment
            {
                Name = name,
                Birthday = birthday,
                Date = date
            };

            appointments.Add(appointment);
        }

        public List<Appointment> Search(string name)
        {
            return appointments
                .Where(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool Delete(string name)
        {
            var appt = appointments.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (appt != null)
            {
                appointments.Remove(appt);
                deletedAppointments.Add(appt);
                return true;
            }
            return false;
        }

        public bool Update(string name, string newDate)
        {
            var appt = appointments.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (appt != null)
            {
                appt.Date = newDate;
                return true;
            }
            return false;
        }

        public bool Retrieve(string name)
        {
            var appt = deletedAppointments.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (appt != null)
            {
                deletedAppointments.Remove(appt);
                appointments.Add(appt);
                return true;
            }
            return false;
        }
    }
}
