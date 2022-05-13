using AwesomeShop.Services.Orders.Domain.Bases;
using System;

namespace AwesomeShop.Services.Orders.Domain.Entities
{
    public class OrderItem : EntityBase<Guid>
    {
        public OrderItem(Guid productId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
        
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}