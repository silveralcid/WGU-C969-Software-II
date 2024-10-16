using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using AMS.UI.Infra.MySQLRepo.EntityBuilders;
using AMS.UI.Infra.MySQLRepo.Queries;
using System;
using System.Collections.Generic;
using System.Data;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    internal class AppointmentRepository : BaseRepository, IRepository<Appointment>
    {
        AppointmentBuilder builder = new AppointmentBuilder();
        AppointmentQueries queries = new AppointmentQueries();

        public bool Create(Appointment entity)
        {
            string query = queries.Insert(entity);
            return DbClient.CreateRecord(query);
        }

        public bool Delete(Appointment entity)
        {
            string query = queries.Delete(entity);
            return DbClient.DeleteRecord(query);
        }

        public IEnumerable<Appointment> GetAll()
        {
            string query = queries.SelectAll();
            var datatable = DbClient.ReadRecord(query);
            List<Appointment> result = new List<Appointment>();

            foreach (DataRow row in datatable.Rows)
            {
                result.Add(builder.Build(row));
            }

            return result;
        }

        public Appointment GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Appointment entity)
        {
            string query = queries.Update(entity);
            return DbClient.UpdateRecord(query);
        }

        public bool HaveOverlapping(int consultantId, int appointmentId, string newStartTime, string newEndTime)
        {
            string query = queries.GetOverlapping(consultantId, appointmentId, newStartTime, newEndTime);
            var datatable = DbClient.ReadRecord(query);

            return datatable.Rows.Count > 0;
        }
    }
}
