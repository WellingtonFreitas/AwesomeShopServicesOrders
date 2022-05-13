using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Dtos.InputModels;
using AwesomeShop.Services.Orders.Domain.Entities;
using AwesomeShop.Services.Orders.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeShop.Services.Orders.Domain.Commands.Add
{
    public class AddOrderRequest : IRequest<ResponseBase>
    {
        public CustomerInputModel Customer { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public PaymentAddressInputModel PaymentAddress { get; set; }
        public PaymentInfoInputModel PaymentInfo { get; set; }

        public Order MapToEntity()
        {
            return new Order(
                new Customer(Customer.Id, Customer.FullName, Customer.Email),
                new DeliveryAddress(DeliveryAddress.Street, DeliveryAddress.Number, DeliveryAddress.City, DeliveryAddress.State, DeliveryAddress.ZipCode),
                new PaymentAddress(PaymentAddress.Street, PaymentAddress.Number, PaymentAddress.City, PaymentAddress.State, PaymentAddress.ZipCode),
                new PaymentInfo(PaymentInfo.CardNumber, PaymentInfo.FullName, PaymentInfo.ExpirationDate, PaymentInfo.Cvv),
                Items.Select(i => new OrderItem(i.ProductId, i.Quantity, i.Price)).ToList()
            );
        }
    }
}
