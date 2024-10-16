using System.Collections.Generic;

namespace AMS.UI.Domain.Interfaces
{
    public interface IRepository<T>
    {
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
