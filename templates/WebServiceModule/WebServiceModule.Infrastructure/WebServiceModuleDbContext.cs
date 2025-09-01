using Microsoft.EntityFrameworkCore;
using WebServiceModule.Domain;

namespace WebServiceModule.Infrastructure;

public sealed class WebServiceModuleDbContext : DbContext
{
    public WebServiceModuleDbContext(DbContextOptions<WebServiceModuleDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ModuleItem> ModuleItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebServiceModuleDbContext).Assembly);
    }
}
