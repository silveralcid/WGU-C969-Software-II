using AMS.UI.Domain.Entities;
using AMS.UI.View_Models.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AMS.UI.Forms.Reports
{
    public partial class ByTypes : Form
    {
        List<Appointment> Appointments;
        public ByTypes(List<Appointment> appointments)
        {
            InitializeComponent();
            Appointments = appointments;
            LoadTable();

            cmbMonths.Items.Add(new CmbOption() { Value = 0, Label = "Select the month" });
            cmbMonths.SelectedIndex = 0;
            var months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int i = 1;
            foreach (var month in months)
            {
                cmbMonths.Items.Add(new CmbOption() { Value = i, Label = month });
                i++;
            }
        }

        private void LoadTable()
        {
            List<Appointment> selectedMonthAppointments = Appointments.Where((appointment) => appointment.StartTime.Month == (cmbMonths.SelectedIndex)).ToList();

            List<string> appointmentTypes = selectedMonthAppointments.Select(
                (appointment) => appointment.Type.ToLower()
            ).Distinct().ToList();

            dvgApointments.Rows.Clear();
            foreach (var appointmentType in appointmentTypes)
            {
                int totalCount = selectedMonthAppointments.Count((appointment) => appointment.Type.ToLower() == appointmentType);

                dvgApointments.Rows.Add(appointmentType, totalCount);
            }
        }

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
