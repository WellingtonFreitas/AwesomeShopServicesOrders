using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using Consul;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Services.ServiceDiscovery
{
    public class ConsulService : IServiceDiscovery
    {
        private readonly IConsulClient _consulClient;
        public ConsulService(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
        public async Task<Uri> GetServiceUri(string serviceName, string requestUri)
        {
            var allRegisterService = await _consulClient.Agent.Services();

            var registeredServices = allRegisterService.Response?.
                Where(s => s.Value.Service.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase))
                .Select(s => s.Value)
                .ToList();

            var service = registeredServices.First();

            var uri = $"http://{service.Address}:{service.Port}/{requestUri}";

            return new Uri(uri);

        }
    }
}
