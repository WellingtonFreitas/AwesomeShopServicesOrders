using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Dtos.ViewModels;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Queries.Orders.GetById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, ResponseBase>
    {
        private readonly IOrderRepository _repository;
        public GetOrderByIdHandler(
            IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseBase> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var order = await _repository.GetByIdAsync(request.Id);
                if (order == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Messages.Add($"Order not found");
                    return response;
                }
                        
                var orderViewModel = OrderViewModel.MapToViewModel(order);

                response.Data.Add(orderViewModel);
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
