namespace TestTask.DataLayer.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    
    Task<T?> FindByIdAsync(Guid id);
    
    Task RemoveAsync(Guid id);
    
    IQueryable<T> Query();
}
