using BookingBL;
using System;
using System.Windows.Forms;

namespace Booking_GUI
{
    public partial class ADD : Form
    {
        public ADD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingProcess bookingProcess = new BookingProcess();

            var name = txtname.Text.Trim();
            var birthday = textbday.Text.Trim();
            var date = textdate.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(birthday) || string.IsNullOrWhiteSpace(date))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!bookingProcess.ValidateDateInput(date))
            {
                MessageBox.Show("Invalid Date. Please use MM-DD-YYYY format.");
                return;
            }

            bookingProcess.Add(name, birthday, date);
            MessageBox.Show("Appointment Added!");

            txtname.Clear();
            textbday.Clear();
            textdate.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ADD_Load(object sender, EventArgs e)
        {

        }
    }
}

