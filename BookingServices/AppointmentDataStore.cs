using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingService
{
    public static class AppointmentDataStore
    {
        private static List<string> appointments = new List<string>();
        private static List<string> deletedAppointments = new List<string>();

        public static void Add(string appointment)
        {
            appointments.Add(appointment);
        }

        public static List<string> GetAll()
        {
            return new List<string>(appointments);
        }

        public static List<string> Search(string name)
        {
            return appointments.Where(appt => appt.Contains($"Name: {name}")).ToList();
        }

        public static bool Delete(string name)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {name}"))
                {
                    deletedAppointments.Add(appointments[i]);
                    appointments.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static bool Update(string name, string newDate)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {name}"))
                {
                    var parts = appointments[i].Split(", ");
                    parts[2] = $"Date: {newDate}";
                    appointments[i] = string.Join(", ", parts);
                    return true;
                }
            }
            return false;
        }

        public static bool Retrieve(string name)
        {
            for (int i = 0; i < deletedAppointments.Count; i++)
            {
                if (deletedAppointments[i].Contains($"Name: {name}"))
                {
                    appointments.Add(deletedAppointments[i]);
                    deletedAppointments.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}