using AwesomeShop.Services.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Interfaces.Services
{
    public interface ICustomerIntegrationService
    {
        Task CreateCustomerUrl(Order order);
    }
}
