using BookingCommon;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BookingServices
{
    public class DataBaseAppointmentRepository : IAppointmentRepository
    {
        private static readonly string connectionString =
            "Data Source=JASMINDEYRO\\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True;TrustServerCertificate=True;";

        private static SqlConnection sqlConnection;

        public DataBaseAppointmentRepository()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(Appointment appointment)
        {
            var insertStatement = "INSERT INTO Appointment (Name, Birthday, Date) VALUES (@Name, @Birthday, @Date)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@Name", appointment.Name);
            insertCommand.Parameters.AddWithValue("@Birthday", appointment.Birthday);
            insertCommand.Parameters.AddWithValue("@Date", appointment.Date);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool Delete(string name)
        {
            
            var backupStatement = @"
                INSERT INTO Deleted (Name, Birthday, Date)
                SELECT Name, Birthday, Date FROM Appointment WHERE Name = @Name";
            SqlCommand backupCommand = new SqlCommand(backupStatement, sqlConnection);
            backupCommand.Parameters.AddWithValue("@Name", name);

          
            var deleteStatement = "DELETE FROM Appointment WHERE Name = @Name";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            backupCommand.ExecuteNonQuery();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0;
        }

        public List<Appointment> GetAll()
        {
            var appointments = new List<Appointment>();
            var selectStatement = "SELECT Name, Birthday, Date FROM Appointment";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                var appointment = new Appointment
                {
                    Name = reader["Name"].ToString(),
                    Birthday = reader["Birthday"].ToString(),
                    Date = reader["Date"].ToString()
                };
                appointments.Add(appointment);
            }

            reader.Close();
            sqlConnection.Close();

            return appointments;
        }

        public bool Retrieve(string name)
        {
            var restoreStatement = @"
                INSERT INTO Appointment (Name, Birthday, Date)
                SELECT Name, Birthday, Date FROM Deleted WHERE Name = @Name;

                DELETE FROM Deleted WHERE Name = @Name;
            ";

            SqlCommand restoreCommand = new SqlCommand(restoreStatement, sqlConnection);
            restoreCommand.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            int rowsAffected = restoreCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0;
        }

        public List<Appointment> Search(string name)
        {
            var appointments = new List<Appointment>();
            var searchStatement = "SELECT Name, Birthday, Date FROM Appointment WHERE Name LIKE @Name";
            SqlCommand searchCommand = new SqlCommand(searchStatement, sqlConnection);
            searchCommand.Parameters.AddWithValue("@Name", "%" + name + "%");

            sqlConnection.Open();
            SqlDataReader reader = searchCommand.ExecuteReader();

            while (reader.Read())
            {
                appointments.Add(new Appointment
                {
                    Name = reader["Name"].ToString(),
                    Birthday = reader["Birthday"].ToString(),
                    Date = reader["Date"].ToString()
                });
            }

            reader.Close();
            sqlConnection.Close();

            return appointments;
        }

        public bool Update(string name, string newDate)
        {
            var updateStatement = "UPDATE Appointment SET Date = @NewDate WHERE Name = @Name";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Name", name);
            updateCommand.Parameters.AddWithValue("@NewDate", newDate);

            sqlConnection.Open();
            int rowsAffected = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0;
        }
    }
}
