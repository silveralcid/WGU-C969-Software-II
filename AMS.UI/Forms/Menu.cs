using AMS.UI.Utils;
using System.Windows.Forms;

namespace AMS.UI.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, System.EventArgs e)
        {
            FormHelper.ReOpenAfterClose(this, new Customers.View());
        }

        private void btnAppointments_Click(object sender, System.EventArgs e)
        {
            FormHelper.ReOpenAfterClose(this, new Apointments.View());
        }

        private void btnReports_Click(object sender, System.EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new Reports.Menu()
            );
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FormHelper.Open(
                this,
                new Login()
            );
        }
    }
}
