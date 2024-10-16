using AMS.UI.Domain.Entities;
using AMS.UI.View_Models.Components;
using AMS.UI.View_Models.Interfaces;

namespace AMS.UI.View_Models.Customers
{
    internal class CreateUpdateVM : IEntityViewModal<Customer>
    {
        public Field CustomerName { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Customer Name",
            IsRequired = true,
        };

        public Field Address { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Address",
            IsRequired = true,
        };

        public Field PostalCode { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Postal Code",
            IsRequired = true,
        };

        public Field City { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "City",
            IsRequired = true,
        };

        public Field Country { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Country",
            IsRequired = true,
        };

        public Field PhoneNumber { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Phone Number",
            IsRequired = true,
        };

        public CreateUpdateVM(Customer customer)
        {
            entityId = customer.Id;
            if (customer.IsPresent)
            {
                addressId = customer.Address.Id;
                CustomerName.Value = customer.Name;
                Address.Value = customer.Address.Line1;
                PostalCode.Value = customer.Address.PostalCode;
                City.Value = customer.Address.City.Name;
                Country.Value = customer.Address.City.Country.Name;
                PhoneNumber.Value = customer.Address.PhoneNumber;
            }
        }

        public bool IsValid()
        {
            Validator.ValidateRequired(CustomerName);
            Validator.ValidateRequired(Address);
            Validator.ValidateRequired(City);
            Validator.ValidateRequired(Country);
            Validator.ValidateRequired(PostalCode);
            Validator.ValidateLength(PostalCode, 10);
            Validator.ValidateRequired(PhoneNumber);
            Validator.ValidatePhoneNumber(PhoneNumber);

            return (
                CustomerName.IsValid &&
                Address.IsValid &&
                City.IsValid &&
                Country.IsValid &&
                PostalCode.IsValid &&
                PhoneNumber.IsValid
            );
        }

        private int entityId;
        private int addressId = 0;
        public Customer ToEntity()
        {
            Customer customer = new Customer()
            {
                Id = entityId,
                Name = CustomerName.Value.Trim(),
                IsActive = true,
                Address = new Address()
                {
                    Id = addressId,
                    Line1 = Address.Value.Trim(),
                    PostalCode = PostalCode.Value.Trim(),
                    PhoneNumber = PhoneNumber.Value.Trim(),
                    City = new City()
                    {
                        Name = City.Value.Trim(),
                        Country = new Country()
                        {
                            Name = Country.Value.Trim()
                        }
                    }
                }
            };

            return customer;
        }
    }
}
