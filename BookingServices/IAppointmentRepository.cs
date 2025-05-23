using System.Collections.Generic;

namespace BookingCommon
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        List<Appointment> GetAll();
        List<Appointment> Search(string name);
        bool Delete(string name);
        bool Update(string name, string newDate);
        bool Retrieve(string name);

    }
}