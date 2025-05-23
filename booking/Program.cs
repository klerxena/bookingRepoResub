using System;
using System.Collections.Generic;
using BookingCommon;
using BookingService;

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
            "[7] Exit"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO LASH & NAILS BOOKING SYSTEM");

            DisplayMenu();
            int userInput = GetUserInput();

            while (userInput != 7)
            {
                switch (userInput)
                {
                    case 1:
                        AddAppointment();
                        break;
                    case 2:
                        ViewAppointments();
                        break;
                    case 3:
                        SearchAppointment();
                        break;
                    case 4:
                        DeleteAppointment();
                        break;
                    case 5:
                        UpdateAppointment();
                        break;
                    case 6:
                        RetrieveAppointment();
                        break;
                    case 7:
                        Console.WriteLine("Thank you for booking with us! Have a great day!");
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION. Please select between 1-7.");
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

        static void AddAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("ADD APPOINTMENT");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Birthday (MM-DD-YYYY): ");
            string birthday = Console.ReadLine();

            Console.Write("Enter Appointment Date (MM-DD-YYYY): ");
            string date = Console.ReadLine();

            if (!ValidateDateInput(date))
            {
                Console.WriteLine("Invalid Date. Please try again.");
            }
            else
            {
                BookingProcess.AddAppointment(name, birthday, date);
                Console.WriteLine("Appointment Added!");
            }
        }

        static void ViewAppointments()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("YOUR APPOINTMENTS");
            if (BookingProcess.appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                foreach (var appt in BookingProcess.appointments)
                {
                    Console.WriteLine("- " + appt);
                }
            }
        }

        static void SearchAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("SEARCH APPOINTMENT");
            Console.Write("Enter Name to Search: ");
            string searchName = Console.ReadLine();

            List<Appointment> results = BookingProcess.SearchAppointment(searchName);

            if (results.Count > 0)
            {
                Console.WriteLine("Appointment(s) found:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        static void DeleteAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("DELETE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Delete: ");
            string nameToDelete = Console.ReadLine();

            string result = BookingProcess.DeleteAppointment(nameToDelete);
            Console.WriteLine(result);
        }

        static void UpdateAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("UPDATE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Update: ");
            string nameToUpdate = Console.ReadLine();

            Console.Write("Enter New Appointment Date (MM-DD-YYYY): ");
            string newDate = Console.ReadLine();

            string result = BookingProcess.UpdateAppointment(nameToUpdate, newDate);
            Console.WriteLine(result);
        }

        static void RetrieveAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("RETRIEVE DELETED APPOINTMENT");
            Console.Write("Enter Name of Appointment to Retrieve: ");
            string nameToRetrieve = Console.ReadLine();

            string result = BookingProcess.RetrieveAppointment(nameToRetrieve);
            Console.WriteLine(result);
        }

        static bool ValidateDateInput(string date)
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                if (parsedDate < DateTime.Today)
                {
                    Console.WriteLine("Invalid Date.");
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
    }
}