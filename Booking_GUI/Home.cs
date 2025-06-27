using System;
using System.Windows.Forms;

namespace Booking_GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ADD aDD = new ADD();
            aDD.Show();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            VIEW vIEW = new VIEW();
            vIEW.Show();
        }
    }
}
