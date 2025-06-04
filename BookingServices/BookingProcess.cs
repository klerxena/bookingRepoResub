using BookingCommon;
using BookingServices;
using System;
using System.Collections.Generic;

public class BookingProcess
{
    //private static IAppointmentRepository repository = new InMemoryAppointmentRepository();
    //private static IAppointmentRepository repository = new TextFileAppointmentRepository();
    //private static IAppointmentRepository repository = new JsonFileAppointmentRepository();
    private static IAppointmentRepository repository = new DataBaseAppointmentRepository();


    public static void SetRepository(IAppointmentRepository newRepo) => repository = newRepo;

    public static bool AddAppointment(string name, string birthday, string date)
    {
        if (string.IsNullOrWhiteSpace(date) || !ValidateDateInput(date)) return false;

        repository.Add(new Appointment
        {
            Name = name,
            Birthday = birthday,
            Date = date
        });

        return true;
    }

    public static List<Appointment> SearchAppointment(string name) =>
        repository.Search(name); 

    public static string DeleteAppointment(string name) =>
        repository.Delete(name) ? "Appointment Deleted." : "Appointment not found.";

    public static string UpdateAppointment(string name, string newDate) =>
        string.IsNullOrWhiteSpace(newDate) || !ValidateDateInput(newDate)
            ? "Invalid Date. Please try again."
            : repository.Update(name, newDate) ? "Appointment Updated." : "Appointment not found.";

    public static string RetrieveAppointment(string name) =>
        repository.Retrieve(name) ? "Appointment Retrieved." : "No deleted appointment found for that name.";

    private static bool ValidateDateInput(string date) => DateTime.TryParse(date, out _);

    public static List<Appointment> appointments => repository.GetAll();
}