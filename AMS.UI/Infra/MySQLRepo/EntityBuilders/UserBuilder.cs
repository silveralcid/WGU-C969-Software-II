using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Interfaces;
using System;
using System.Data;

namespace AMS.UI.Infra.MySQLRepo.EntityBuilders
{
    internal class UserBuilder : IEntityBuilder<User>
    {
        public User Build(DataRow dbRow)
        {
            User user = new User()
            {
                Id = Convert.ToInt32(dbRow["userId"]),
                UserName = Convert.ToString(dbRow["userName"]),
                Password = Convert.ToString(dbRow["password"]),
                IsActive = Convert.ToBoolean(dbRow["active"])
            };
            Utils.AssignBaseEntityValues(user, dbRow);

            return user;
        }
    }
}
