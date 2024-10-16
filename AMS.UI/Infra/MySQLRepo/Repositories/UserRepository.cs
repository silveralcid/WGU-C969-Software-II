using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Exceptions;
using AMS.UI.Infra.MySQLRepo.EntityBuilders;
using AMS.UI.Infra.MySQLRepo.Queries;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    public class UserRepository : BaseRepository
    {
        readonly UserBuilder builder = new UserBuilder();
        readonly UserQueries queries = new UserQueries();

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                string query = queries.GetUserByUserNameAndPassword(userName, password);
                var datatable = DbClient.ReadRecord(query);
                DataRow row = EntityBuilders.Utils.GetFirstRow(datatable);
                return builder.Build(row);
            }
            catch (RecordNotFoundException)
            {
                return new User();
            }
        }

        public IEnumerable<User> GetAll()
        {
            string query = queries.SelectAll();
            var datatable = DbClient.ReadRecord(query);
            List<User> users = new List<User>();
            foreach (DataRow row in datatable.Rows)
            {
                users.Add(builder.Build(row));
            }

            return users;
        }
    }
}
