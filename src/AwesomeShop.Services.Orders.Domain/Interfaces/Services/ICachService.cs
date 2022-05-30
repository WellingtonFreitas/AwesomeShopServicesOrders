using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Interfaces.Services
{
    public interface ICachService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T data);
    }
}
