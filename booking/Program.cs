using BookingBL;
using Microsoft.Extensions.Configuration; // <-- This is from the new package
using System;
using System.IO; // <-- This is new

namespace booking
{
    internal class Program
    {
        static string[] actions = new string[]
        {
            "[1] Add Appointment",
            "[2] View Appointments",
            "[3] Search Appointment",
            "[4] Delete Appointment",
            "[5] Update Appointment",
            "[6] Retrieve Deleted Appointment",
            "[7] Send Notification Email",
            "[8] Exit"
        };

        static void Main(string[] args)
        {
            // 1. Build the configuration (from Copilot suggestion)
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Create the services manually (from Copilot suggestion)
            EmailService emailService = new EmailService(config);
            BookingProcess bookingProcess = new BookingProcess(emailService);

            // 3. Now the app starts
            Console.WriteLine("WELCOME TO LASH & NAILS BOOKING SYSTEM");

            DisplayMenu();
            int userInput = GetUserInput();

            while (userInput != 8)
            {
                switch (userInput)
                {
                    case 1:
                        AddAppointment(bookingProcess); // <-- Pass the object
                        break;
                    case 2:
                        ViewAppointments(bookingProcess); // <-- Pass the object
                        break;
                    case 3:
                        SearchAppointment(bookingProcess); // <-- Pass the object
                        break;
                    case 4:
                        DeleteAppointment(bookingProcess); // <-- Pass the object
                        break;
                    case 5:
                        UpdateAppointment(bookingProcess); // <-- Pass the object
                        break;
                    case 6:
                        RetrieveAppointment(bookingProcess); // <-- Pass the object
                        break;
                    case 7:
                        SendNotificationEmail(bookingProcess); // <-- Pass the object
                        break;
                    case 8:
                        Console.WriteLine("Thank you for booking with us! Have a great day!");
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION. Please select between 1-8.");
                        break;
                }
                DisplayMenu();
                userInput = GetUserInput();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("BOOKING MENU");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]: ");
            return Convert.ToInt16(Console.ReadLine());
        }

        // --- All methods below now take BookingProcess as a parameter ---

        static void AddAppointment(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("ADD APPOINTMENT");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Birthday (MM-DD-YYYY): ");
            string birthday = Console.ReadLine();

            Console.Write("Enter Appointment Date (MM-DD-YYYY): ");
            string date = Console.ReadLine();

            if (!bookingProcess.ValidateDateInput(date))
            {
                Console.WriteLine("Invalid Date. Please try again.");
            }
            else
            {
                bookingProcess.Add(name, birthday, date);
                Console.WriteLine("Appointment Added!");
            }
        }

        static void ViewAppointments(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("YOUR APPOINTMENTS");
            var appointments = bookingProcess.GetAll();
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                foreach (var appt in appointments)
                {
                    Console.WriteLine($"- {appt.Name}, {appt.Birthday}, {appt.Date}");
                }
            }
        }

        static void SearchAppointment(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("SEARCH APPOINTMENT");
            Console.Write("Enter Name to Search: ");
            string searchName = Console.ReadLine();

            var results = bookingProcess.Search(searchName);

            if (results.Count > 0)
            {
                Console.WriteLine("Appointment(s) found:");
                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Name}, {result.Birthday}, {result.Date}");
                }
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        static void DeleteAppointment(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("DELETE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Delete: ");
            string nameToDelete = Console.ReadLine();

            bool result = bookingProcess.Delete(nameToDelete);
            Console.WriteLine(result ? "Appointment deleted." : "Appointment not found.");
        }

        static void UpdateAppointment(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("UPDATE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Update: ");
            string nameToUpdate = Console.ReadLine();

            Console.Write("Enter New Appointment Date (MM-DD-YYYY): ");
            string newDate = Console.ReadLine();

            bool result = bookingProcess.Update(nameToUpdate, newDate);
            Console.WriteLine(result ? "Appointment updated." : "Appointment not found.");
        }

        static void RetrieveAppointment(BookingProcess bookingProcess)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("RETRIEVE DELETED APPOINTMENT");
            Console.Write("Enter Name of Appointment to Retrieve: ");
            string nameToRetrieve = Console.ReadLine();

            bool result = bookingProcess.Retrieve(nameToRetrieve);
            Console.WriteLine(result ? "Appointment retrieved." : "Appointment not found.");
        }

        // This is the updated method, as suggested by Copilot
        static void SendNotificationEmail(BookingProcess bookingProcess)
        {
            // We no longer create a new BookingProcess here
            Console.WriteLine("----------------");
            Console.WriteLine("SEND NOTIFICATION EMAIL");
            Console.Write("Enter recipient email: ");
            string toEmail = Console.ReadLine();
            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter message body: ");
            string body = Console.ReadLine();

            // This will work now
            bool sent = bookingProcess.SendNotification(toEmail, subject, body);
            Console.WriteLine(sent ? "Email sent successfully!" : "Failed to send email.");
        }
    }
}