using BookingCommon;
using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryAppointmentRepository : IAppointmentRepository
{
    private List<Appointment> appointments = new();
    private List<Appointment> deletedAppointments = new();
    public InMemoryAppointmentRepository()
    {
        LoadDefaultAppointments();
    }

    private void LoadDefaultAppointments()
    {
        appointments.Add(new Appointment { Name = "Alice", Birthday = "1990-02-02", Date = "2025-07-15" });
        appointments.Add(new Appointment { Name = "Bob", Birthday = "1985-11-20", Date = "2025-08-01" });
        appointments.Add(new Appointment { Name = "Charlie", Birthday = "2000-05-05", Date = "2025-09-10" });
    }



    public List<Appointment> GetAll()
    {
        return new List<Appointment>(appointments);
    }

    public List<Appointment> Search(string name)
    {
        return appointments
            .Where(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool Delete(string name)
    {
        var index = appointments.FindIndex(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
            deletedAppointments.Add(appointments[index]);
            appointments.RemoveAt(index);
            return true;
        }
        return false;
    }

    public bool Update(string name, string newDate)
    {
        var appointment = appointments.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (appointment != null)
        {
            appointment.Date = newDate;
            return true;
        }
        return false;
    }

    public bool Retrieve(string name)
    {
        var index = deletedAppointments.FindIndex(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
            appointments.Add(deletedAppointments[index]);
            deletedAppointments.RemoveAt(index);
            return true;
        }
        return false;
    }



    public void Add(Appointment appointment)
    {
        appointments.Add(appointment);
    }

    public void Add(string v)
    {
        throw new NotImplementedException();
    }
}