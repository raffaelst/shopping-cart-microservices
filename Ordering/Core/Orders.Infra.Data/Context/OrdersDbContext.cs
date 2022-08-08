
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polly;
using Orders.Domain.Entities;

namespace Orders.Infra.Data.Context
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);

            var converter = new EnumToStringConverter<Status>();
            builder
                .Entity<Order>(u =>
                {
                    u.HasKey(b => b.OrderId);
                    u.Property(b => b.OrderId).ValueGeneratedOnAdd();
                    u.Property(p => p.Status).HasConversion(converter);
                });

            builder
                .Entity<OrderItem>(u =>
                {
                    u.HasKey(b => b.OrderItemId);
                    u.Property(b => b.OrderItemId).ValueGeneratedOnAdd();
                });
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }
    }
}
