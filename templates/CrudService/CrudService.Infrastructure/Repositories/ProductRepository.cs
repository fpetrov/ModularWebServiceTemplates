using CrudService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudService.Infrastructure.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<Product?> GetById(int id, CancellationToken ct = default)
    {
        return await db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<List<Product>> GetAll(CancellationToken ct = default)
    {
        return await db.Products
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task Add(Product product, CancellationToken ct = default)
    {
        await db.Products.AddAsync(product, ct);
        await db.SaveChangesAsync(ct);
    }

    public async Task Update(Product product)
    {
        db.Products.Update(product);
        await db.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        db.Products.Remove(product);
        await db.SaveChangesAsync();
    }
}