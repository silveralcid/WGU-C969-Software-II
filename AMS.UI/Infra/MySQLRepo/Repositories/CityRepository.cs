using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    internal class CityRepository : IRepository<City>
    {
        public City GetCityByName(City city)
        {
            var customers = CustomerRepository.Customers;

            foreach (var customer in customers)
            {
                var persistedCity = customer.Address.City;
                if (persistedCity.Name.ToLower().Equals(city.Name.ToLower()))
                {
                    return persistedCity;
                }
            }

            return null;
        }

        public int CountCitiesByCountryName(Country country)
        {
            var customers = CustomerRepository.Customers;
            var cityCount = 0;

            foreach (var customer in customers)
            {
                var persistedCity = customer.Address.City;
                if (persistedCity.Country.Id == country.Id)
                {
                    cityCount += 1;
                }
            }

            return cityCount;
        }

        public bool Create(City entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(City entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(City entity)
        {
            throw new NotImplementedException();
        }
    }
}
