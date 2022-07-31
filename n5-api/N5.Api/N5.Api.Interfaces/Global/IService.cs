namespace N5.Api.Interfaces.Global
{
    public interface IService<TR,T>
    {
        Task<TR?> Get(int id);
        List<TR> GetAll();
        Task<TR> Add(T entity);
        Task<TR> Update(T entity);
    }
}