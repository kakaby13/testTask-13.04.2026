using Microsoft.EntityFrameworkCore;

namespace TestTask.DataLayer.Repositories;

public class GenericRepository<T>(AppDbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _set = context.Set<T>();

    public Task AddAsync(T entity)
    {
        return _set.AddAsync(entity).AsTask();
    }
    
    public Task<T?> FindByIdAsync(Guid id)
    {
        return _set.FindAsync(id).AsTask();
    }

    public void Update(T entity)
    {
        _set.Update(entity);
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await _set.FindAsync(id);
        if (entity == null)
            throw new Exception("Entity not found"); // todo

        _set.Remove(entity);
    }


    public IQueryable<T> Query()
    {
        return _set.AsQueryable();
    }
}
