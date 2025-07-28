using CrudService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudService.Infrastructure.Repositories;

public class ProductRepository(ApplicationContext db) : GenericRepository<Product>(db), IProductRepository
{
    public Task<Product> SomeCustom(int id)
    {
        return Task.FromResult(
            new Product(id, string.Empty, 0));
    }
}