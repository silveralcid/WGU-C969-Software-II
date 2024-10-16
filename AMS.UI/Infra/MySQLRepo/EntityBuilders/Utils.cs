using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Exceptions;
using System;
using System.Data;

namespace AMS.UI.Infra.MySQLRepo.EntityBuilders
{
    internal static class Utils
    {
        public static void AssignBaseEntityValues(BaseEntity entity, DataRow dbRow)
        {
            entity.CreatedAt = Convert.ToDateTime(dbRow["createDate"]);
            entity.LastUpdatedAt = Convert.ToDateTime(dbRow["lastUpdate"]);
            entity.CreatedBy = Convert.ToString(dbRow["createdBy"]);
            entity.LastUpdatedBy = Convert.ToString(dbRow["lastUpdateBy"]);
        }

        public static DataRow GetFirstRow(DataTable datatable)
        {
            try
            {
                var datarows = datatable.Rows;
                return datarows[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new RecordNotFoundException();
            }
        }
    }
}
