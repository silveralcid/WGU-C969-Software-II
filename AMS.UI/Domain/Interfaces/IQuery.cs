namespace AMS.UI.Domain.Interfaces
{
    public interface IQuery<T>
    {
        string Insert(T entity);
        string Delete(T entity);
        string Update(T entity);
        string SelectById(int id);
        string SelectAll();
    }
}
