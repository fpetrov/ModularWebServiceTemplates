using CrudService.Domain.Specifications;

namespace CrudService.Domain;

public interface IGenericRepository<T>
    where T : Entity
{
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<T>> ListAsync(ISpecification<T>? specification = null, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    Task Update(T entity);
    Task Delete(T entity);
}