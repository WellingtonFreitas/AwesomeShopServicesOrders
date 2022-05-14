using AwesomeShop.Services.Orders.Data.Persistence;
using AwesomeShop.Services.Orders.Data.Persistence.Repositories;
using AwesomeShop.Services.Orders.Domain.Commands.Add;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeShop.Services.Orders.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddServicesDependenciesInjection(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddOrderRequest));
        }

        public static void AddRepositoriesDependenciesInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBContext, MongoDbContext>();

            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
