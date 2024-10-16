using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;

namespace AMS.UI.Infra.MySQLRepo.Queries
{
    internal class UserQueries : IQuery<User>
    {
        public string GetUserByUserNameAndPassword(string userName, string password)
        {
            return $"SELECT * FROM user WHERE userName = '{userName}' AND password = '{password}'";
        }

        public string Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public string Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public string SelectAll()
        {
            return "SELECT * FROM user";
        }

        public string SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Update(User entity)
        {
            throw new System.NotImplementedException();
        }

    }
}
