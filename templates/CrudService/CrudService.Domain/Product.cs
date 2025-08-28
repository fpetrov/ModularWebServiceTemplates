using CrudService.Domain.Common.Validation;
using JetBrains.Annotations;

namespace CrudService.Domain;

public class Product
{
    public int Id { get; protected set; }

    public string Name { get; private set; }

    public int Price { get; private set; }

    public Product(int id, string name, int price)
    {
        Validate(name, price);

        Id = id;
        Name = name;
        Price = price;
    }

    public void Update(string name, int price)
    {
        Validate(name, price);

        Name = name;
        Price = price;
    }

    private void Validate(string name, int price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Validation.InRangeOrThrow(price, 0, 999);
    }

    [UsedImplicitly]
    private Product()
    {
        Name = null!;
        Price = 0;
    }
}