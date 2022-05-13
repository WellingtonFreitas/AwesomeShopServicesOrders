using AwesomeShop.Services.Orders.Domain.Bases;
using MediatR;
using System;

namespace AwesomeShop.Services.Orders.Domain.Queries.Orders.GetById
{
    public class GetOrderByIdRequest : IRequest<ResponseBase>
    {
        public GetOrderByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
