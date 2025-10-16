using BookingCommon;
using BookingDL;
using System.Net;
using System.Net.Mail;

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

        public bool ValidateDateInput(string date)
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                if (parsedDate < DateTime.Today)
                {
                    Console.WriteLine("Invalid Date. Date must not be in the past.");
                    return false;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Date Format. Use MM-DD-YYYY.");
                return false;
            }
        }

        public bool SendNotification(string toEmail, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("01030d68f1b7aa", "1375c01a9a5aef"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("jasminclaire@deyro.com"),
                    Subject = subject ?? string.Empty,
                    Body = body ?? string.Empty
                };
                mailMessage.To.Add(toEmail ?? string.Empty);

                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email send failed: {ex.Message}");
                return false;
            }
        }
    }
}
