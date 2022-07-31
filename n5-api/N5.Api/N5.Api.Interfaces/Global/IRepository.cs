namespace N5.Api.Interfaces.Global
{
    public interface IRepository<T>
    {
        Task<T?> Get(int id);
        IEnumerable<T> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
    }
}