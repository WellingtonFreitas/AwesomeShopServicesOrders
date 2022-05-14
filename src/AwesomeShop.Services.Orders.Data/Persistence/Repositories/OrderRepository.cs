using AwesomeShop.Services.Orders.Domain.Entities;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Data.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository(IMongoDBContext mongoDBContext)
        {
            _collection = mongoDBContext.GetCollection<Order>("Orders");
        }
        public async Task AddAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _collection.Find(o => o.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            await _collection.ReplaceOneAsync(o => o.Id.Equals(order.Id), order);
        }
    }
}
