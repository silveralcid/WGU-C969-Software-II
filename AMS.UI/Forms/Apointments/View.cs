using AMS.UI.Domain.Entities;
using AMS.UI.Forms.Appointments;
using AMS.UI.UseCases.Appointments;
using AMS.UI.UseCases.Consultants;
using AMS.UI.Utils;
using AMS.UI.View_Models.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AMS.UI.Forms.Apointments
{
    public partial class View : Form
    {
        List<Appointment> Appointments;
        Appointment selectedAppointment;
        List<User> Consultants = ConsultantService.GetAll();

        public View()
        {
            InitializeComponent();
        }
        private void View_Load(object sender, EventArgs e)
        {
            LoadTable();

            cmbConsultant.Items.Add(new CmbOption() { Value = 0, Label = "All Consultants" });
            foreach (var consultant in Consultants)
            {
                cmbConsultant.Items.Add(new CmbOption() { Value = consultant.Id, Label = consultant.UserName });
            }

            cmbDays.SelectedIndex = 0;
        }

        #region Private
        private void LoadTable()
        {
            CmbOption selectedConsultant = cmbConsultant.SelectedItem as CmbOption;
            
            // selectedConsultant is null when nothing is selected, its value will be 0 when all is selected
            Appointments = AppointmentService.GetAll().FindAll(
                (appointment) => (selectedConsultant == null || selectedConsultant.Value == 0) || (appointment.User.Id == selectedConsultant.Value)
            );

            // filter by selected option:
            DateTime Today = DateTime.Now;
            List<Appointment> filteredAppointments = new List<Appointment>();
            dateTimePicker1.Enabled = false;
            cmbDays.Enabled = false;

            if (rbAll.Checked)
            {
                filteredAppointments = Appointments;
            }
            else if (rbCurrentMonth.Checked)
            {
                filteredAppointments = FilterByCurrentMonth(Today);
            }
            else if (rbCurrentWeek.Checked)
            {
                filteredAppointments = FilterByCurrentWeek(Today);
            }
            else if (rbSpecificDate.Checked)
            {
                dateTimePicker1.Enabled = true;
                filteredAppointments = FilterBySpecificDate(dateTimePicker1.Value);
            }
            else if (rbSpecificDay.Checked)
            {
                cmbDays.Enabled = true;
                filteredAppointments = FilterBySpecificDay(cmbDays.SelectedIndex);
            }

            dgvAppointments.Rows.Clear();
            foreach (var appointment in filteredAppointments)
            {
                dgvAppointments.Rows.Add(
                    appointment.Id,
                    appointment.Customer.Name,
                    appointment.User.UserName,
                    appointment.Title,
                    appointment.Description,
                    appointment.Location,
                    appointment.Contact,
                    appointment.Type,
                    appointment.URL,
                    appointment.StartTime,
                    appointment.EndTime
                );
            }
            setSelectedAppointment();
        }

        private void setSelectedAppointment()
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["colId"].Value);
                selectedAppointment = Appointments.Find((appointment) => appointment.Id == appointmentId);
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new CreateUpdateForm(
                    new Appointment()
                )
            );
            LoadTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new CreateUpdateForm(selectedAppointment)
            );
            LoadTable();
        }

        private void dgvAppointments_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // this can only have null errors, so we can ignore;
            try
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells[0].Value);
                selectedAppointment = Appointments.Find(selectedAppointment => selectedAppointment.Id == appointmentId);
            }
            catch (Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(selectedAppointment != null)
            {
                try
                {
                    if (AppointmentService.Delete(selectedAppointment))
                    {
                        MessageBox.Show("Selected appointment is successfully Deleted!");
                        LoadTable();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the selected appointment!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to delete the selected appointment!");
                }
            }
            else
            {
                MessageBox.Show("No Appointment is selected");
            }

        }

        private void rbCurrentMonth_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbCurrentWeek_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private List<Appointment> FilterByCurrentMonth(DateTime Today)
        {
            List<Appointment> filteredAppointments = new List<Appointment>();
            DateTime thisMonthStartDate = new DateTime(Today.Year, Today.Month, 1);
            int lastDayOfMonth = DateTime.DaysInMonth(Today.Year, Today.Month);
            DateTime thisMonthEndDate = new DateTime(Today.Year, Today.Month, lastDayOfMonth);
            foreach (var appointment in Appointments)
            {
                if (appointment.StartTime.Date >= thisMonthStartDate.Date && appointment.EndTime.Date <= thisMonthEndDate.Date)
                {
                    filteredAppointments.Add(appointment);
                }
            }

            return filteredAppointments;
        }

        private List<Appointment> FilterByCurrentWeek(DateTime Today)
        {
            List<Appointment> filteredAppointments = new List<Appointment>();
            int daysToSubtract = (int)Today.DayOfWeek;
            DateTime startOfWeek = Today.AddDays(-daysToSubtract).Date; // Start of the week (Sunday)
            DateTime endOfWeek = startOfWeek.AddDays(6); // End of the week (Saturday)
            foreach (var appointment in Appointments)
            {
                if (appointment.StartTime.Date >= startOfWeek.Date && appointment.EndTime.Date <= endOfWeek.Date)
                {
                    filteredAppointments.Add(appointment);
                }
            }

            return filteredAppointments;
        }

        private List<Appointment> FilterBySpecificDate(DateTime dateTime)
        {
            List<Appointment> filteredAppointments = new List<Appointment>();
            foreach (var appointment in Appointments)
            {
                if (appointment.StartTime.Date >= dateTime.Date && appointment.EndTime.Date <= dateTime.Date)
                {
                    filteredAppointments.Add(appointment);
                }
            }

            return filteredAppointments;
        }

        private List<Appointment> FilterBySpecificDay(int day)
        {
            DayOfWeek dayOfWeek = (DayOfWeek)day;
            List<Appointment> filteredAppointments = new List<Appointment>();
            foreach (var appointment in Appointments)
            {
                if (appointment.StartTime.Date.DayOfWeek >= dayOfWeek && appointment.EndTime.Date.DayOfWeek <= dayOfWeek)
                {
                    filteredAppointments.Add(appointment);
                }
            }

            return filteredAppointments;
        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbSpecificDay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
