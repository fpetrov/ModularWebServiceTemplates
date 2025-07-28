using CrudService.Domain;
using CrudService.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CrudService.Infrastructure.Repositories;

public class GenericRepository<T>(ApplicationContext db) : IGenericRepository<T>
    where T : Entity
{
    public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        => await db.Set<T>().FindAsync([id], ct);

    public async Task<List<T>> ListAsync(ISpecification<T>? spec = null, CancellationToken ct = default)
    {
        IQueryable<T> query = db.Set<T>();

        if (spec is null)
            return await query.ToListAsync(ct);
        
        query = query.Where(spec.Criteria);
        query = spec.Includes.Aggregate(query,
            (q, include) => q.Include(include));
        
        return await query.ToListAsync(ct);
    }

    public async Task AddAsync(T e, CancellationToken ct = default)
    {
        await db.Set<T>().AddAsync(e, ct);
        await db.SaveChangesAsync(ct);
    }
    
    public Task Update(T e)
    {
        db.Set<T>().Update(e);
        return db.SaveChangesAsync();
    }
    
    public Task Delete(T e)
    {
        db.Set<T>().Remove(e);
        return db.SaveChangesAsync();
    }
}