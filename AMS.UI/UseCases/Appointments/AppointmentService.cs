using AMS.UI.Domain.Entities;
using AMS.UI.Infra.MySQLRepo.Repositories;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMS.UI.UseCases.Appointments
{
    internal class AppointmentService
    {
        private static AppointmentRepository repository = new AppointmentRepository();

        public static List<Appointment> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public static bool HaveOverlappingAppointments(int consultantId, int appointmentId, DateTime startDate, DateTime endDate)
        {
            return repository.HaveOverlapping(
                consultantId,
                appointmentId,
                formatDateTime(startDate.ToUniversalTime()),
                formatDateTime(endDate.ToUniversalTime())
            );
        }

        public static bool Save(Appointment appointment)
        {
            // These times are needed to be stored in UTC so that we can use local timezones
            appointment.StartTime = appointment.StartTime.ToUniversalTime();
            appointment.EndTime = appointment.EndTime.ToUniversalTime();

            if (!appointment.IsPresent) return repository.Create(appointment);

            return repository.Update(appointment);
        }

        public static bool Delete(Appointment appointment)
        {
            if (appointment.IsPresent)
            {
                return repository.Delete(appointment);
            }

            return false;
        }

        public static List<Appointment> GetAppointmentsWithin15Mins()
        {
            DateTime startTimeIn15Mins = DateTime.Now.AddMinutes(15);

            List<Appointment> appointments = GetAll();
            List<Appointment> withIn15Mins = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                var diffInMinutes = (startTimeIn15Mins - appointment.StartTime).TotalMinutes;
                if (diffInMinutes >= 0 && diffInMinutes <= 15)
                {
                    withIn15Mins.Add(appointment);
                }
            }

            return withIn15Mins;
        }

        private static string formatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
