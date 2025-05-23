using BookingCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonFileAppointmentRepository : IAppointmentRepository
{
    private readonly string filePath = "appointments.json";
    private readonly string deletedPath = "deleted.json";
    private List<Appointment> appointments = new();
    private List<Appointment> deletedAppointments = new();

    public JsonFileAppointmentRepository()
    {
        LoadData();
    }

    private void LoadData()
    {
        appointments = LoadFromFile(filePath);
        deletedAppointments = LoadFromFile(deletedPath);
    }

    private List<Appointment> LoadFromFile(string path)
    {
        if (!File.Exists(path)) return new List<Appointment>();
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
    }

    private void SaveToFile(string path, List<Appointment> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
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
            SaveToFile(filePath, appointments);
            SaveToFile(deletedPath, deletedAppointments);
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
            SaveToFile(filePath, appointments);
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
            SaveToFile(filePath, appointments);
            SaveToFile(deletedPath, deletedAppointments);
            return true;
        }
        return false;
    }

    public void Add(Appointment appointment)
    {
        appointments.Add(appointment);
        SaveToFile(filePath, appointments);
    }
}