using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.View_Models;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class CustomerQueries : IQuery<Customer>
    {
        public string Insert(Customer entity)
        {
            int active = entity.IsActive ? 1 : 0;
            return $"INSERT INTO customer(" +
                        $"customerName," +
                        $"addressId," +
                        $"active," +
                        $"createDate," +
                        $"createdBy," +
                        $"lastUpdate," +
                        $"lastUpdateBy" +
                    $") VALUES (" +
                        $"'{entity.Name}'," +
                        $"{entity.Address.Id}," +
                        $"{active}," +
                        $"NOW()," +
                        $"'{Store.CurrentUser.UserName}'," +
                        $"NOW()," +
                        $"'{Store.CurrentUser.UserName}'" +
                    $");";
        }

        public string Delete(Customer entity)
        {
            return $"DELETE from customer where customerId = {entity.Id};";
        }

        public string Update(Customer entity)
        {
            return $"UPDATE customer SET customerName = '{entity.Name}', addressId = {entity.Address.Id}, lastUpdate = NOW(), lastUpdateBy = '{Store.CurrentUser.UserName}' WHERE customerId = {entity.Id};";
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string SelectAll()
        {
            return @"SELECT 
                        *
                    FROM
                        customer AS c
                    INNER JOIN
                        address AS a ON c.addressId = a.addressId
                    INNER JOIN
                        city AS ci ON a.cityId = ci.cityId
                    INNER JOIN
                        country AS co ON ci.countryId = co.countryId;";
        }
    }
}
