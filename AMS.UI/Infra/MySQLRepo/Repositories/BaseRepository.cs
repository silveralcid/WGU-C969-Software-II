using AMS.UI.Domain.Interfaces;

namespace AMS.UI.Infra.MySQLRepo.Repositories
{
    public class BaseRepository
    {
        protected IDbClient DbClient { get; set; } = new MySqlClient();
    }
}
