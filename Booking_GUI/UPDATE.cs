using BookingBL;
using System;
using System.Windows.Forms;

namespace Booking_GUI
{
    public partial class UPDATE : Form
    {
        public UPDATE(string name, string birthday, string date)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = birthday;
            textBox3.Text = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingProcess bookingProcess = new BookingProcess();

            string name = textBox1.Text.Trim();
            string newDate = textBox3.Text.Trim();

            if (!bookingProcess.ValidateDateInput(newDate))
            {
                MessageBox.Show("Invalid date format. Please enter MM-DD-YYYY.");
                return;
            }

            bool result = bookingProcess.Update(name, newDate);

            if (result)
            {
                MessageBox.Show("Appointment successfully updated!");
                Close();
            }
            else
            {
                MessageBox.Show("Appointment not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookingProcess bookingProcess = new BookingProcess();
            string name = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name to retrieve.");
                return;
            }

            bool result = bookingProcess.Retrieve(name);

            if (result)
            {
                MessageBox.Show("Appointment successfully retrieved!");
                Close();
            }
            else
            {
                MessageBox.Show("Deleted appointment not found.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
