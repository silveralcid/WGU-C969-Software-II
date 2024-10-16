using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.Infra.MySQLRepo.Repositories;
using AMS.UI.View_Models;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class AddressQueries : IQuery<Address>
    {
        public string Delete(Address entity)
        {
            return $"DELETE from address where addressId = {entity.Id};";
        }

        public string Insert(Address entity)
        {
            return $"INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{entity.Line1}','{entity.Line2}',{entity.City.Id},'{entity.PostalCode}','{entity.PhoneNumber}',NOW(),'{Store.CurrentUser.UserName}',NOW(),'{Store.CurrentUser.UserName}');";
        }

        public string SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Update(Address entity)
        {
            return $"UPDATE address SET address = '{entity.Line1}', address2 = '{entity.Line2}', cityId = {entity.City.Id}, postalCode = '{entity.PostalCode}', phone = '{entity.PhoneNumber}', lastUpdate = NOW(), lastUpdateBy = '{Store.CurrentUser.UserName}' WHERE addressId = {entity.Id};";
        }

        public int CountAddressByCityName(City city)
        {
            var customers = CustomerRepository.Customers;
            var addressCount = 0;

            foreach (var customer in customers)
            {
                var persistedAddress = customer.Address;
                if (persistedAddress.City.Id == city.Id)
                {
                    addressCount += 1;
                }
            }

            return addressCount;
        }
    }
}
