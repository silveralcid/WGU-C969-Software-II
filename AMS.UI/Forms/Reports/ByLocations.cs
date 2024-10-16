using AMS.UI.Domain.Entities;
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
    public partial class ByLocations : Form
    {
        List<Appointment> Appointments;
        public ByLocations(List<Appointment> appointments)
        {
            InitializeComponent();
            Appointments = appointments;
            LoadTable();
        }

        private void LoadTable()
        {
            List<string> locations = Appointments.Select(
                (appointment) => appointment.Location.ToLower()
            ).Distinct().ToList();

            foreach (var location in locations)
            {
                int totalCount = Appointments.Count((appointment) => appointment.Location.ToLower() == location);

                dvgApointments.Rows.Add(location, totalCount);
            }
        }
    }
}
