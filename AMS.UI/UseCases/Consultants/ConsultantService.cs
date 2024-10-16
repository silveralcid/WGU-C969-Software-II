using AMS.UI.Domain.Entities;
using AMS.UI.Infra.MySQLRepo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AMS.UI.UseCases.Consultants
{
    internal static class ConsultantService
    {
        public static UserRepository repository { get; set; } = new UserRepository();

        public static List<User> GetAll()
        {
            return repository.GetAll().ToList();
        }
    }
}
