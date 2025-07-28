namespace CrudService.Domain;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> SomeCustom(int id);
}