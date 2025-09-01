using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebServiceModule.Domain;

namespace WebServiceModule.Infrastructure.Configurations;

public class ModuleItemConfiguration : IEntityTypeConfiguration<ModuleItem>
{
    public void Configure(EntityTypeBuilder<ModuleItem> builder)
    {
        builder.Property(s => s.Id).ValueGeneratedNever();
    }
}
