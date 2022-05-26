using AwesomeShop.Services.Orders.Domain.Dtos.Integration;
using AwesomeShop.Services.Orders.Domain.Entities;
using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Services.Services
{
    public class CustomerIntegrationService : ICustomerIntegrationService
    {
        private readonly IServiceDiscovery _serviceDiscovery;
        public CustomerIntegrationService(
            IServiceDiscovery serviceDiscovery)
        {
            _serviceDiscovery = serviceDiscovery;
        }

        public async Task CreateCustomerUrl(Order order) 
        {
            var custumerUrl = await _serviceDiscovery.GetServiceUri("CustomerServices", $"/api/customers/{order.Customer.Id}");
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(custumerUrl);
            var stringResult = await result.Content.ReadAsStringAsync();
            var customerDto = JsonConvert.DeserializeObject<GetCustomerByIdDto>(stringResult);
            Console.WriteLine(customerDto);
            
        }
    }
}
