using System;

namespace AwesomeShop.Services.Orders.Domain.Dtos.InputModels
{
    public class OrderItemInputModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
