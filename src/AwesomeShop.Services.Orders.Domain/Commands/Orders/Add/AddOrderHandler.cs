using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Commands.Orders.Add;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using AwesomeShop.Services.Orders.Extensions;
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
        private readonly IMessageBusClient _messageBus;
        public AddOrderHandler(
            IOrderRepository repository,
            IMessageBusClient messageBus)
        {
            _repository = repository;
            _messageBus = messageBus;   
        }

        public async Task<ResponseBase> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            AddOrderRequestResponse response = new AddOrderRequestResponse();
            try
            {
                var order = request.MapToEntity();

                await _repository.AddAsync(order);

                foreach (var @event in order.Events)
                {
                    var routingKey =  @event.GetType().Name.ToDashCase();
                    _messageBus.Publish(message: @event,routingKey: routingKey, exchange: "order-service");
                }

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