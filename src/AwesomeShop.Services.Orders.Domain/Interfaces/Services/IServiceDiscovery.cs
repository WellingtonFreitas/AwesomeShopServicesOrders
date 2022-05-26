using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Interfaces.Services
{
    public interface IServiceDiscovery
    {
        Task<Uri> GetServiceUri(string serviceName, string requestUri);
    }
}
