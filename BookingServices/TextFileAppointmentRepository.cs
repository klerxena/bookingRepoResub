using BookingCommon;

namespace BookingDL
{
    public class TextFileAppointmentRepository : IAppointmentRepository
    {
        private string filePath = "appointments.txt";
        private string deletedPath = "deleted.txt";
        private List<Appointment> appointments = new List<Appointment>();

        public TextFileAppointmentRepository()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            appointments.Clear();

            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var appt = ParseAppointmentFromLine(line);
                if (appt != null)
                    appointments.Add(appt);
            }
        }

        private void SaveToFile()
        {
            var lines = appointments.Select(a => $"{a.Name}|{a.Birthday}|{a.Date}").ToArray();
            File.WriteAllLines(filePath, lines);
        }

        private Appointment ParseAppointmentFromLine(string line)
        {
            var parts = line.Split('|');
            if (parts.Length < 3) return null;

            return new Appointment
            {
                Name = parts[0],
                Birthday = parts[1],
                Date = parts[2]
            };
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
            SaveToFile();
        }

        public List<Appointment> GetAll()
        {
            return appointments;
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
                var appt = appointments[index];
                File.AppendAllLines(deletedPath, new[] { $"{appt.Name}|{appt.Birthday}|{appt.Date}" });
                appointments.RemoveAt(index);
                SaveToFile();
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
                SaveToFile();
                return true;
            }
            return false;
        }

        public bool Retrieve(string name)
        {
            if (!File.Exists(deletedPath)) return false;

            var deleted = File.ReadAllLines(deletedPath).ToList();
            var line = deleted.FirstOrDefault(l => l.StartsWith(name + "|", StringComparison.OrdinalIgnoreCase));
            if (line != null)
            {
                var appt = ParseAppointmentFromLine(line);
                if (appt != null)
                {
                    appointments.Add(appt);
                    deleted.Remove(line);
                    File.WriteAllLines(deletedPath, deleted);
                    SaveToFile();
                    return true;
                }
            }

            return false;
        }
    }
}