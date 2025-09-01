using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebServiceModule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServiceModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WebServiceModuleDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WebServiceModule")));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}
