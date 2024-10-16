using AMS.UI.Domain.Entities;
using AMS.UI.View_Models.Components;
using AMS.UI.View_Models.Interfaces;
using System;

namespace AMS.UI.View_Models.Appointments
{
    internal class CreateUpdateVM : IViewModel, IEntityViewModal<Appointment>
    {
        readonly static string DefaultValue = "not needed";

        public Field CustomerName { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Customer Name",
            IsRequired = true
        };

        public Field ConsultantName { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Consultant Name",
            IsRequired = true
        };

        public Field Title { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Title",
            IsRequired = true,
            Value = DefaultValue
        };

        public Field Description { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Description",
            IsRequired = true,
            Value = DefaultValue
        };

        public Field Location { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Location",
            IsRequired = true,
        };
        
        public Field Contact { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Contact",
            IsRequired = true,
        };
        
        public Field Type { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Type",
            IsRequired = true,
        };
        
        public Field URL { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "URL",
            IsRequired = true,
        };
        
        public Field StartTime { get; set; } = new Field()
        {
            FieldType = FieldType.DATETIME,
            Name = "Start Time",
            IsRequired = true,
        };
        
        public Field EndTime { get; set; } = new Field()
        {
            FieldType = FieldType.DATETIME,
            Name = "End Time",
            IsRequired = true,
        };

        int appointmentId = 0;
        public int consultantId = 0;

        public CreateUpdateVM(Appointment appointment) 
        {
            CustomerName.Value = appointment.Customer?.Name;
            ConsultantName.Value = appointment.User?.UserName;
            Title.Value = appointment.Title;
            Description.Value = appointment.Description;
            Location.Value = appointment.Location;
            Contact.Value = appointment.Contact;
            Type.Value = appointment.Type;
            URL.Value = appointment.URL;
            StartTime.Value = appointment.StartTime.ToString();
            EndTime.Value = appointment.EndTime.ToString();
            appointmentId = appointment.Id;
        }

        public bool IsValid()
        {
            Validator.ValidateRequired(CustomerName);
            Validator.ValidateRequired(ConsultantName);
            Validator.ValidateRequired(Title);
            Validator.ValidateRequired(Description);
            Validator.ValidateRequired(Location);
            Validator.ValidateRequired(Contact);
            Validator.ValidateRequired(Type);
            Validator.ValidateRequired(URL);
            Validator.ValidateBusinessHours(StartTime, EndTime);
            Validator.ValidateOverlappingTime(consultantId, appointmentId, StartTime, EndTime);

            return (
                CustomerName.IsValid &&
                ConsultantName.IsValid &&
                Title.IsValid &&
                Description.IsValid &&
                Location.IsValid &&
                Contact.IsValid &&
                Type.IsValid &&
                URL.IsValid &&
                StartTime.IsValid &&
                EndTime.IsValid
            );
        }

        public Appointment ToEntity()
        {
            return new Appointment()
            {
                Title = Title.Value,
                Description = Description.Value,
                Location = Location.Value,
                Type = Type.Value,
                URL = URL.Value,
                Contact = Contact.Value,
                StartTime = Convert.ToDateTime(StartTime.Value),
                EndTime = Convert.ToDateTime(EndTime.Value),
            };
        }
    }
}
