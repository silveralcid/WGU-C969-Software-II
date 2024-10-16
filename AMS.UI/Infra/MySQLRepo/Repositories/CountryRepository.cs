using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using System.Collections.Generic;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    internal class CountryRepository : IRepository<Country>
    {
        public Country GetCountryByName(Country country)
        {
            var customers = CustomerRepository.Customers;

            foreach (var customer in customers)
            {
                var persistedCountry = customer.Address.City.Country;
                if (persistedCountry.Name.ToLower().Equals(country.Name.ToLower()))
                {
                    return persistedCountry;
                }
            }

            return null;
        }

        public bool Create(Country entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Country entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Country GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Country entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
