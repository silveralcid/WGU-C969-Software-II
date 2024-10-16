using AMS.UI.Domain.Entities;
using AMS.UI.UseCases.Appointments;
using AMS.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.UI.Forms.Reports
{
    public partial class Menu : Form
    {
        List<Appointment> Appointments = AppointmentService.GetAll();

        public Menu()
        {
            InitializeComponent();
        }

        private void btnAppointmentTypes_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new ByTypes(Appointments)
            );
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new ByLocations(Appointments)
            );
        }
    }
}
