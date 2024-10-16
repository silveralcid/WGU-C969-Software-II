using AMS.UI.Domain.Entities;
using AMS.UI.Domain.Exceptions;
using AMS.UI.Infra.MySQLRepo.Repositories;

namespace AMS.UI.UseCases.Auth
{
    public static class AuthService
    {
        public static User Authenticate(string username, string password)
        {
            var user = new UserRepository().GetUserByUserNameAndPassword(
                username,
                password
            );

            if (!user.IsPresent)
            {
                throw new NotAuthorizedException();
            }

            return user;
        }
    }
}
