namespace CrudService.Domain.Specifications.Products;

public class ProductsByCategorySpecification : Specification<Product>
{
    public ProductsByCategorySpecification(string name, int minPrice)
    {
        Criteria = p => p.Name == name && p.Price < minPrice;
        // AddInclude(p => p.Nesting);
    }
}