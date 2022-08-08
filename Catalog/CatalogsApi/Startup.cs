using MassTransit;
using CatalogsApi.Hubs;
using CatalogsApi.Messages.Consumers;
using Messaging.InterfacesConstants.Constants;
using GreenPipes;
using Catalogs.Infra.IoC;
using Catalogs.Infra.Data.Context;

namespace CatalogsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<CatalogsContext>(options => options.UseSqlServer
            //(
            //    Configuration.GetConnectionString("CatalogsConnection")
            //));

            services.AddInfrastructure(Configuration);
            services.AddHttpClient();
            services.AddSignalR()
                .AddJsonProtocol(opts =>
                {
                    opts.PayloadSerializerOptions.PropertyNamingPolicy = null;
                });

            //services.AddTransient<IProductRepository, ProductRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<RegisterOrderCommandConsumer>();
                //x.AddConsumer<OrderDispatchedEventConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://rabbitmq"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint(RabbitMqMassTransitConstants.RegisterOrderCommandQueue, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<RegisterOrderCommandConsumer>(provider);

                    });
                    //cfg.ReceiveEndpoint(RabbitMqMassTransitConstants.OrderDispatchedServiceQueue, ep =>
                    //{
                    //    ep.PrefetchCount = 16;
                    //    ep.UseMessageRetry(r => r.Interval(2, 100));
                    //    ep.ConfigureConsumer<OrderDispatchedEventConsumer>(provider);

                    //});

                }));
            });
            services.AddMassTransitHostedService();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed((host) => true)
                       .AllowCredentials());


            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<OrderHub>("/orderhub");
            });
            using var scope = app.ApplicationServices.
               GetRequiredService<IServiceScopeFactory>().
               CreateScope();
            scope.ServiceProvider.GetService<ProductsContext>().MigrateDB();
        }
    }
}
