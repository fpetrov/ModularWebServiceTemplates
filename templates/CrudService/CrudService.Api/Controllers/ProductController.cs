using CrudService.Contracts.Products;
using CrudService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CrudService.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken ct)
    {
        var products = await repository.ListAsync(null, ct);
        var result = products.Select(Map).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
    {
        var product = await repository.GetByIdAsync(id, ct);
        return product is null ? NotFound() : Ok(Map(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductRequest request, CancellationToken ct)
    {
        var product = new Product(0, request.Name, request.Price);
        await repository.AddAsync(product, ct);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, Map(product));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request, CancellationToken ct)
    {
        var product = await repository.GetByIdAsync(id, ct);
        if (product is null)
            return NotFound();

        product.Update(request.Name, request.Price);
        await repository.Update(product);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var product = await repository.GetByIdAsync(id, ct);
        if (product is null)
            return NotFound();

        await repository.Delete(product);
        return NoContent();
    }

    private static ProductDto Map(Product product) => new(product.Id, product.Name, product.Price);
}
