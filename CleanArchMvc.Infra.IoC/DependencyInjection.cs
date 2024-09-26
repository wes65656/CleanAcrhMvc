using CleanArchMvc.Aplication.Interfaces;
using CleanArchMvc.Aplication.Mappings;
using CleanArchMvc.Aplication.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Aplication");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductService).Assembly));
        
        return services;
    }
}