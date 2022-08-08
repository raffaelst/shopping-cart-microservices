using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Interface.Interfaces;
using Orders.Application.Mappings;
using Orders.Application.Services;
using Orders.Infra.Data.Context;
using Orders.Infra.Data.Repositories;
using Orders.Repository.Interface;

namespace Orders.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrdersConnection"
                ), b => b.MigrationsAssembly(typeof(OrdersDbContext).Assembly.FullName)));


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
