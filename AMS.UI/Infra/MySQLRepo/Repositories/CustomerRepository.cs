using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.Infra.MySQLRepo.EntityBuilders;
using AMS.UI.Infra.MySQLRepo.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        readonly CustomerBuilder builder = new CustomerBuilder();
        
        readonly CustomerQueries queries = new CustomerQueries();
        readonly CountryQueries countryQueries = new CountryQueries();
        readonly CityQueries cityQueries = new CityQueries();

        readonly CityRepository cityRepository = new CityRepository();
        readonly CountryRepository countryRepository = new CountryRepository();

        readonly AddressQueries addressQueries = new AddressQueries();
        readonly AppointmentQueries appointmentQueries = new AppointmentQueries();

        public static List<Customer> Customers { get; set; }

        public bool Delete(Customer entity)
        {
            var query1 = appointmentQueries.DeleteByCustomer(entity);
            var query = queries.Delete(entity);
                
            var fullQuery = query1 + query;

            return DbClient.DeleteRecord(fullQuery);
        }

        public IEnumerable<Customer> GetAll()
        {
            string query = queries.SelectAll();
            var datatable = DbClient.ReadRecord(query);
            List<Customer> result = new List<Customer>();

            foreach (DataRow row in datatable.Rows)
            {
                result.Add(builder.Build(row));
            }
            Customers = result; // store customers

            return result;
        }

        public Customer GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Customer entity)
        {
            SaveCountry(entity.Address.City.Country, entity.Address.City);
            SaveCity(entity.Address.City);
            SaveAddress(entity.Address);

            string query = queries.Insert(entity);

            return DbClient.CreateRecord(query);
        }

        private void SaveAddress(Address addressToSave)
        {
            var query = addressQueries.Insert(addressToSave);
            int addressId = DbClient.CreateScaler(query);
            addressToSave.Id = addressId;
        }

        private void UpdateAddress(Address addressToUpdate)
        {
            var query = addressQueries.Update(addressToUpdate);
            DbClient.UpdateRecord(query);
        }

        public bool Update(Customer entity)
        {
            SaveCountry(entity.Address.City.Country, entity.Address.City);
            SaveCity(entity.Address.City);
            UpdateAddress(entity.Address);
            var query = queries.Update(entity);

            return DbClient.UpdateRecord(query);
        }

        public void SaveCountry(Country countryToSave, City cityToSave)
        {
            var country = countryRepository.GetCountryByName(countryToSave);

            if (country == null)
            {
                var query = countryQueries.Insert(countryToSave);
                int countryId = DbClient.CreateScaler(query);
                countryToSave.Id = countryId;
                return;
            }

            countryToSave.Id = country.Id;
            cityToSave.Country.Id = country.Id;
        }

        public void SaveCity(City cityToSave)
        {
            var city = cityRepository.GetCityByName(cityToSave);

            if (city == null)
            {
                var query = cityQueries.Insert(cityToSave);
                int cityId = DbClient.CreateScaler(query);
                cityToSave.Id = cityId;
                return;
            }

            cityToSave.Id = city.Id;
        }

    }
}
