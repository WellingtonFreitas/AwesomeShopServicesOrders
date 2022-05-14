using AwesomeShop.Services.Orders.Domain.Entities;
using System;

namespace AwesomeShop.Services.Orders.Domain.Dtos.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel(Guid id, decimal totalPrice, string createdAt, string status)
        {
            Id = id;
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
            this.status = status;
        }

        public Guid Id { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string CreatedAt { get; private set; }
        public string status { get; private set; }

        public static OrderViewModel MapToViewModel(Order order)
        {
            return new OrderViewModel(order.Id, order.TotalPrice, order.CreatedAt.ToString("g"), order.Status.ToString());
        }
    }
}