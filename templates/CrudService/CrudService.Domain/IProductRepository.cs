namespace CrudService.Domain;

public interface IProductRepository
{
    Task<Product?> GetById(int id, CancellationToken ct = default);
    Task<List<Product>> GetAll(CancellationToken ct = default);
    Task Add(Product product, CancellationToken ct = default);
    Task Update(Product product);
    Task Delete(Product product);
}