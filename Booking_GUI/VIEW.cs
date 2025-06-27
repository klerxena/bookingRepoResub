using BookingBL;
using System;
using System.Windows.Forms;

namespace Booking_GUI
{
    public partial class VIEW : Form
    {
        public VIEW()
        {
            InitializeComponent();
            Load += VIEW_Load;
        }

        private void VIEW_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            BookingProcess bookingProcess = new BookingProcess();
            var appointments = bookingProcess.GetAll();

            dataGridView1.AutoGenerateColumns = false;
            Column1.DataPropertyName = "Name";
            Column2.DataPropertyName = "Birthday";
            Column3.DataPropertyName = "Date";

            dataGridView1.DataSource = appointments;
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            var cell = row.Cells[columnName];
            return cell?.Value?.ToString() ?? string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingProcess bookingProcess = new BookingProcess();
            string searchName = search.Text.Trim();

            var results = bookingProcess.Search(searchName);

            if (results.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = results;
            }
            else
            {
                MessageBox.Show("Appointment not found.");
                LoadAppointments();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string name = GetCellValue(row, "Column1");
                string birthday = GetCellValue(row, "Column2");
                string date = GetCellValue(row, "Column3");

                UPDATE updateForm = new UPDATE(name, birthday, date);
                updateForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string name = GetCellValue(row, "Column1");
                string birthday = GetCellValue(row, "Column2");
                string date = GetCellValue(row, "Column3");

                UPDATE retrieveForm = new UPDATE(name, birthday, date);
                retrieveForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string name = GetCellValue(row, "Column1");

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the appointment for '{name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BookingProcess bookingProcess = new BookingProcess();
                    bool deleted = bookingProcess.Delete(name);

                    if (deleted)
                    {
                        MessageBox.Show("Appointment successfully deleted.");
                        LoadAppointments();
                    }
                    else
                    {
                        MessageBox.Show("Appointment not found or could not be deleted.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            search.Clear();
            LoadAppointments();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
