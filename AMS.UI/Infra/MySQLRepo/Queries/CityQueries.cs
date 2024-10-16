using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.View_Models;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class CityQueries : IQuery<City>
    {
        public string Delete(City entity)
        {
           return $"DELETE from city where cityId = {entity.Id};";
        }

        public string Insert(City entity)
        {
            return $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                   $"VALUES ('{entity.Name}',{entity.Country.Id},NOW(),'{entity.CreatedBy}',NOW(),'{entity.LastUpdatedBy}');";
        }

        public string SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Update(City entity)
        {
            return $"UPDATE city SET city = '{entity.Name}', countryId = {entity.Country.Id}, lastUpdate = NOW(), lastUpdateBy = '{Store.CurrentUser.UserName}'";
        }
    }
}
