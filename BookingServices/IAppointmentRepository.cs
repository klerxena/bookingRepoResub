using BookingCommon;
using System.Collections.Generic;

namespace BookingDL
{
    public interface IAppointmentRepository
    {
        void Add(string name, string birthday, string date);
        List<Appointment> GetAll();
        List<Appointment> Search(string name);
        bool Delete(string name);
        bool Update(string name, string newDate);
        bool Retrieve(string name);

    }
}