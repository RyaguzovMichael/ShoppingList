using CommonRepository.Interfaces;
using CommonRepository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CommonRepository;

public abstract class RepositoryBase<T, C> : IBaseRepository<T> where T : EntityBase where C : DbContext
{
    protected readonly C DbContext;

    public RepositoryBase(C dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = DbContext.Set<T>();
        if (predicate != null) query = query.Where(predicate);
        if (orderBy != null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        DbContext.Set<T>().Add(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        entity.LastModifiedDate = DateTime.Now;
        if (entity.LastModifiedBy == null) throw new InvalidOperationException("Unknown author of the change");
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }
}
