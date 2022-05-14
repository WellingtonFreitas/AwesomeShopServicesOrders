using AwesomeShop.Services.Orders.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}