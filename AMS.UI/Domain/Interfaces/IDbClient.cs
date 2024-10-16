using System.Data;

namespace AMS.UI.Domain.Interfaces
{
    public interface IDbClient
    {
        bool CreateRecord(params string[] queries);
        bool DeleteRecord(params string[] queries);
        bool UpdateRecord(params string[] queries);
        int CreateScaler(string query);
        DataTable ReadRecord(string query);
    }
}
