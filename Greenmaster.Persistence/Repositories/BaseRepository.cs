using Greenmaster.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Persistence.Repositories;

public class BaseRepository<T>(BotanicalDbContext context) : IAsyncRepository<T> where T : class
{

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}