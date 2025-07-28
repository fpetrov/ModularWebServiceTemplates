using CrudService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudService.Infrastructure.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .Property(p => p.Price)
            .IsRequired();
    }
}