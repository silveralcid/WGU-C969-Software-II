using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.View_Models;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class CountryQueries : IQuery<Country>
    {

        public string Delete(Country entity)
        {
            return $"DELETE from country where countryId = {entity.Id};";
        }

        public string Insert(Country entity)
        {
            return $"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                   $"VALUES ('{entity.Name}', NOW(),'{Store.CurrentUser.UserName}',NOW(),'{Store.CurrentUser.UserName}');";
        }

        public string SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Update(Country entity)
        {
            return $"UPDATE country SET country='{entity.Name}', lastUpdate=NOW(), lastUpdateBy='{Store.CurrentUser.UserName}' WHERE countryId = {entity.Id};";
        }
    }
}
