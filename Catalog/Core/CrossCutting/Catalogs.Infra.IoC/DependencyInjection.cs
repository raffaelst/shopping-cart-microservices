using Catalogs.Application.Interface.Interfaces;
using Catalogs.Application.Mappings;
using Catalogs.Application.Services;
using Catalogs.Infra.Data.Context;
using Catalogs.Infra.Data.Repositories;
using Catalogs.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogs.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogsConnection"
                ), b => b.MigrationsAssembly(typeof(ProductsContext).Assembly.FullName)));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
