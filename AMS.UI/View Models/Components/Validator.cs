using AMS.UI.Domain.Entities;
using AMS.UI.UseCases.Appointments;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AMS.UI.View_Models.Components
{
    internal static class Validator
    {
        public static void ValidateRequired(Field field)
        {
            string requiredMessage = $"{field.Name} cannot be blank!";
            bool setError = field.IsRequired && !field.IsPresent;

            HandleErrorMessage(field, setError, requiredMessage);
        }

        public static void ValidateLength(Field field, int length)
        {
            string errorMessage = $"{field.Name} cannot exceed {length} characters!";

            bool setError = field.Value.Length > length ;
            HandleErrorMessage(field, setError, errorMessage);
        }

        public static void ValidatePhoneNumber(Field field)
        {
            string invalidPhoneNumberMessage = $"{field.Name} field allows only digits and dashes";
            bool setError = !field.IsValid || !IsDigitsAndDashes(field.Value);

            HandleErrorMessage(field, setError, invalidPhoneNumberMessage);
        }

        public static void ValidateBusinessHours(Field startDateField, Field endDateField)
        {
            if(startDateField.FieldType != FieldType.DATETIME || endDateField.FieldType != FieldType.DATETIME)
            {
                throw new Exception("Field must be a date time type");
            }

            DateTime startDate = Convert.ToDateTime(startDateField.Value);
            DateTime endDate = Convert.ToDateTime(endDateField.Value);

            if(startDate.Day != endDate.Day)
            {
                HandleErrorMessage(startDateField, true, "Start and End Time should be on same day!");
                HandleErrorMessage(endDateField, false, "");
                return;
            }

            string invalidStartMessage = $"{startDateField.Name} can only be scheduled during the business hours of 9:00 a.m. to 5:00 p.m., Monday–Friday, eastern standard time";
            string invalidEndMessage = $"{endDateField.Name} can only be scheduled during the business hours of 9:00 a.m. to 5:00 p.m., Monday–Friday, eastern standard time";
            bool setStartError = !IsWithInBusinessHours(startDate);
            bool setEndError = !IsWithInBusinessHours(endDate);

            HandleErrorMessage(startDateField, setStartError, invalidStartMessage);
            HandleErrorMessage(endDateField, setEndError, invalidEndMessage);
        }

        internal static void ValidateOverlappingTime(int consultantId, int appointmentId, Field startDateField, Field endDateField)
        {
            if (startDateField.FieldType != FieldType.DATETIME || endDateField.FieldType != FieldType.DATETIME)
            {
                throw new Exception("Field must be a date time type");
            }

            DateTime startDate = Convert.ToDateTime(startDateField.Value);
            DateTime endDate = Convert.ToDateTime(endDateField.Value);

            bool isOverlapping = AppointmentService.HaveOverlappingAppointments(consultantId, appointmentId, startDate, endDate);
            bool setError = isOverlapping;
            string invalidMessge = $"You already have appointment between {startDate.ToShortTimeString()} - {endDate.ToShortTimeString()}";

            if (startDateField.IsValid)
            {
                HandleErrorMessage(startDateField, setError, invalidMessge);
            }
        }

        #region PrivateMethods

        private static void HandleErrorMessage(Field field, bool setError, string msg)
        {
            if (setError)
            {
                field.SetError(msg);
            }
            else
            {
                field.RemoveError();
            }
        }

        private static bool IsDigitsAndDashes(string value)
        {
            if(string.IsNullOrEmpty(value)) { return false; }

            // Regular expression to match only digits and dashes
            string pattern = @"^[\d-]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(value.ToString());
        }

        private static bool IsWithInBusinessHours(DateTime datetime)
        {
            // Convert the UTC DateTime to Eastern Standard Time
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime dateTimeUtc = datetime.ToUniversalTime();
            DateTime dateTimeEst = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, est);

            if (dateTimeEst.DayOfWeek == DayOfWeek.Saturday || dateTimeEst.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            TimeSpan start = new TimeSpan(9, 0, 0); // 9:00 AM
            TimeSpan end = new TimeSpan(17, 0, 0);  // 5:00 PM
            TimeSpan time = dateTimeEst.TimeOfDay;

            return time >= start && time <= end;
        }

        

        #endregion

    }
}
