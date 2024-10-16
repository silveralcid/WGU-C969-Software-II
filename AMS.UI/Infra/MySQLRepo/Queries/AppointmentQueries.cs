using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.View_Models;
using System;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class AppointmentQueries : IQuery<Appointment>
    {
        public string Delete(Appointment entity)
        {
            return $"DELETE from appointment WHERE appointmentId = {entity.Id}";
        }

        public string DeleteByCustomer(Customer customer)
        {
            return $"DELETE from appointment WHERE customerId = {customer.Id};";
        }

        public string Insert(Appointment entity)
        {
            return "INSERT INTO appointment(" +
                        "customerId, " +
                        "userId, " +
                        "title, " +
                        "description, " +
                        "location, " +
                        "contact, " +
                        "type, " +
                        "url, " +
                        "start, " +
                        "end, " +
                        "createDate, " +
                        "createdBy, " +
                        "lastUpdate, " +
                        "lastUpdateBy" +
                    ") " +
                   $"VALUES (" +
                       $"{entity.Customer.Id}, " +
                       $"{entity.User.Id}," +
                       $"'{entity.Title}'," +
                       $"'{entity.Description}'," +
                       $"'{entity.Location}'," +
                       $"'{entity.Contact}'," +
                       $"'{entity.Type}'," +
                       $"'{entity.URL}'," +
                       $"'{formatDateTime(entity.StartTime)}'," +
                       $"'{formatDateTime(entity.EndTime)}'," +
                       $"NOW()," +
                       $"'{Store.CurrentUser.UserName}'," +
                       $"NOW()," +
                       $"'{Store.CurrentUser.UserName}'" +
                   $");";
        }

        public string SelectAll()
        {
            return $@"
                        SELECT * 
                        FROM appointment a
                        INNER JOIN customer c ON a.customerId = c.customerId
                        INNER JOIN user u ON u.userId = a.userId;
                    ";
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Update(Appointment entity)
        {
            return "UPDATE appointment " +
                   " SET " +
                       $"customerId = {entity.Customer.Id}," +
                       $"userId = {entity.User.Id}," +
                       $"title = '{entity.Title}'," +
                       $"description = '{entity.Description}'," +
                       $"location = '{entity.Location}'," +
                       $"contact = '{entity.Contact}'," +
                       $"type = '{entity.Type}'," +
                       $"url = '{entity.URL}'," +
                       $"start = '{formatDateTime(entity.StartTime)}'," +
                       $"end = '{formatDateTime(entity.EndTime)}'," +
                       $"lastUpdate = NOW()," +
                       $"lastUpdateBy = '{Store.CurrentUser.UserName}'" +
                   $"WHERE appointmentId = {entity.Id};";
        }

        public string GetOverlapping(int consultantId, int appointmentId, string startDate, string endDate)
        {
            return "SELECT appointmentId " +
                   "FROM appointment " +
                   $"WHERE userId = {consultantId} AND appointmentId <> {appointmentId} AND start <= '{endDate}' AND end >= '{startDate}';";
        }

        private static string formatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
