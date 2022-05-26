using AwesomeShop.Services.Orders.Data.Persistence;
using AwesomeShop.Services.Orders.Data.Persistence.Repositories;
using AwesomeShop.Services.Orders.Domain.Commands.Add;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using AwesomeShop.Services.Orders.Services.MessageBus;
using AwesomeShop.Services.Orders.Services.ServiceDiscovery;
using AwesomeShop.Services.Orders.Services.Services;
using AwesomeShop.Services.Orders.Services.Subscribers;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AwesomeShop.Services.Orders.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddServicesDependenciesInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(AddOrderRequest));

            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = config.GetValue<string>("Consul:Host");

                consulConfig.Address = new Uri(address);
            }));

            services.AddTransient<IServiceDiscovery, ConsulService>();
            services.AddTransient<ICustomerIntegrationService, CustomerIntegrationService>();
        }

        public static void AddRepositoriesDependenciesInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBContext, MongoDbContext>();

            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void AddMessageBus(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();
        }

        public static void AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<PaymentAcceptedSubscriber>();
        }

        public static void UserConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration
            {
                ID = $"order-service-{Guid.NewGuid()}",
                Name = "OrderServices",
                Address = "localhost",
                Port = 5003
            };

            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifeTime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });

        }
    }
}
