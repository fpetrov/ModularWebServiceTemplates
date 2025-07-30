using CrudService.Domain;
using CrudService.Infrastructure;
using CrudService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

#if (swagger)
builder.Services.AddOpenApi();
#endif

var app = builder.Build();

#if (swagger)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}
#endif

app.MapControllers();

app.Run();