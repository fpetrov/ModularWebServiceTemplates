using BotServiceModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BotServiceModule.Infrastructure;

internal class BotServiceModuleDbContext(DbContextOptions<BotServiceModuleDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
}
