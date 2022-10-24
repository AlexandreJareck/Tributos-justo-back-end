using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Notifications;
using AppCrud.Business.Services;
using AppCrud.Data.Context;
using AppCrud.Data.Repository;

namespace AppCrud.Api.Configuration
{

    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppCrudDbContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
