using System;

namespace BookingCommon
{
    public class Appointment
    {
        private string _date = "01-01-2000";
        public string Date
        {
            get { return _date; }
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedDate))
                {
                    _date = parsedDate.ToString("MM-dd-yyyy");
                }
            }
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Birthday: {Birthday}, Date: {Date}";
        }
    }
}
