using AwesomeShop.Services.Orders.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository<TIdentifier>
    {
        Task<Order> GetByIdAsync(TIdentifier id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}