using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using System.Data;

namespace AMS.UI.Infra.MySQLRepo.EntityBuilders
{
    internal class CustomerBuilder : BaseBuilder, IEntityBuilder<Customer>
    {
        public Customer Build(DataRow dbRow)
        {
            Customer customer = BuildCustomer(dbRow);
            customer.Address = BuildAddress(dbRow);

            return customer;
        }

        private Customer BuildCustomer(DataRow dbRow)
        {
            return new Customer()
            {
                Id = ToInt(dbRow["customerId"]),
                Name = ToString(dbRow["customerName"]),
                IsActive = ToBoolean(dbRow["active"]),
                CreatedAt = ToDateTime(dbRow["createDate"]),
                CreatedBy = ToString(dbRow["createdBy"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy"]),
            };
        }


        private Address BuildAddress(DataRow dbRow)
        {
            Address address = new Address()
            {
                Id = ToInt(dbRow["addressId"]),
                Line1 = ToString(dbRow["address"]),
                Line2 = ToString(dbRow["address2"]),
                PostalCode = ToString(dbRow["postalCode"]),
                PhoneNumber = ToString(dbRow["phone"]),
                CreatedAt = ToDateTime(dbRow["createDate1"]),
                CreatedBy = ToString(dbRow["createdBy1"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate1"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy1"]),
            };

            address.City = BuildCity(dbRow);

            return address;
        }

        private City BuildCity(DataRow dbRow)
        {
            City city = new City()
            {
                Id = ToInt(dbRow["cityId"]),
                Name = ToString(dbRow["city"]),
                CreatedAt = ToDateTime(dbRow["createDate2"]),
                CreatedBy = ToString(dbRow["createdBy2"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate2"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy2"]),
            };

            city.Country = BuildCounty(dbRow);

            return city;
        }

        private Country BuildCounty(DataRow dbRow)
        {
            return new Country()
            {
                Id = ToInt(dbRow["countryId"]),
                Name = ToString(dbRow["country"]),
                CreatedAt = ToDateTime(dbRow["createDate3"]),
                CreatedBy = ToString(dbRow["createdBy3"]),
                LastUpdatedAt = ToDateTime(dbRow["lastUpdate3"]),
                LastUpdatedBy = ToString(dbRow["lastUpdateBy3"]),
            };
        }
    }
}
