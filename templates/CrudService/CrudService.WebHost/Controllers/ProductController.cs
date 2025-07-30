using CrudService.Contracts.Products;
using CrudService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CrudService.WebHost.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken ct)
    {
        var products = await repository.GetAll(ct);
        var result = products.Select(Map).ToList();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
    {
        var product = await repository.GetById(id, ct);
        
        return product is null ? NotFound() : Ok(Map(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto, CancellationToken ct)
    {
        var product = new Product(0, dto.Name, dto.Price);
        await repository.Add(product, ct);
        
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, Map(product));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto, CancellationToken ct)
    {
        var product = await repository.GetById(id, ct);
        if (product is null)
            return NotFound();

        product.Update(dto.Name, dto.Price);
        await repository.Update(product);
        
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var product = await repository.GetById(id, ct);
        if (product is null)
            return NotFound();

        await repository.Delete(product);
        
        return NoContent();
    }

    private static ProductDto Map(Product product) => new(product.Id, product.Name, product.Price);
}
