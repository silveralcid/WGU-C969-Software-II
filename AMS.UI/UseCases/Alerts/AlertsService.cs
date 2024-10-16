using AMS.UI.UseCases.Appointments;
using System.Windows.Forms;

namespace AMS.UI.UseCases.Alerts
{
    internal static class AlertsService
    {
        public static void AppointmentsWithIn15MinsAlerts()
        {
            var appointments = AppointmentService.GetAppointmentsWithin15Mins();
            if (appointments.Count > 0)
            {
                string appointmentsAlert = "";
                foreach (var appointment in appointments)
                {
                    appointmentsAlert += $"{appointment.Customer.Name} at {appointment.StartTime.ToLongTimeString()}\n";
                }

                MessageBox.Show($"You have following meetings with:\n{appointmentsAlert}", "Appointment Alerts");
            }
        }
    }
}
