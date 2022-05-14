using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Commands.Orders.Add;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Commands.Add
{
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, ResponseBase>
    {
        private readonly IOrderRepository _repository;
        public AddOrderHandler(
            IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBase> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            AddOrderRequestResponse response = new AddOrderRequestResponse();
            try
            {
                var order = request.MapToEntity();
                await _repository.AddAsync(order);

                response.Id = order.Id;
                response.StatusCode = HttpStatusCode.OK;
                response.Messages.Add($"Success");

                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add($"{ex.Message}");
                return response;
            }
        }
    }
}