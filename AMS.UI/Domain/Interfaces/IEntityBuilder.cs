using System.Data;

namespace AMS.UI.Domain.Interfaces
{
    public interface IEntityBuilder<T>
    {
        T Build(DataRow dbRow);
    }
}
