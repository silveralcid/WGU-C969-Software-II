using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.View_Models;
using System.Data;

namespace AMS.UI.Infra.MySQLRepo.EntityBuilders
{
    internal class AppointmentBuilder : BaseBuilder, IEntityBuilder<Appointment>
    {
        UserBuilder userBuilder = new UserBuilder();

        public Appointment Build(DataRow dbRow)
        {
            Appointment appointment = new Appointment()
            {
                Id = ToInt(dbRow["appointmentId"]),
                User = userBuilder.Build(dbRow),
                Title = ToString(dbRow["title"]),
                Description = ToString(dbRow["description"]),
                Location = ToString(dbRow["location"]),
                Contact = ToString(dbRow["contact"]),
                Type = ToString(dbRow["type"]),
                URL = ToString(dbRow["url"]),
                StartTime = ToDateTime(dbRow["start"]).ToLocalTime(),
                EndTime = ToDateTime(dbRow["end"]).ToLocalTime(),
                CreatedAt = ToDateTime(dbRow["createDate"]),
                CreatedBy = ToString(dbRow["createdBy"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy"]),
            };

            appointment.Customer = new Customer()
            {
                Id = ToInt(dbRow["customerId"]),
                Name = ToString(dbRow["customerName"]),
                IsActive = ToBoolean(dbRow["active"]),
                CreatedAt = ToDateTime(dbRow["createDate1"]),
                CreatedBy = ToString(dbRow["createdBy1"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate1"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy1"]),
            };

            return appointment;
        }
    }
}
