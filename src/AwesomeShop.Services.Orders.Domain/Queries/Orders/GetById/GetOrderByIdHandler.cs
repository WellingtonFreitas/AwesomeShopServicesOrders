using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Dtos.ViewModels;
using AwesomeShop.Services.Orders.Domain.Entities;
using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
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
        private readonly ICachService _cachService;
        public GetOrderByIdHandler(
            IOrderRepository repository,
            ICachService cachService
            )
        {
            _repository = repository;
            _cachService = cachService;
        }
        public async Task<ResponseBase> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var cacheKey = request.Id.ToString();

                var order = await _cachService.GetAsync<Order>(cacheKey);
                if (order == null)
                {
                    order = await _repository.GetByIdAsync(request.Id);
                    if (order == null)
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.Messages.Add($"Order not found");
                        return response;
                    }
                    else
                        await _cachService.SetAsync(cacheKey, order);
                }

                response.Data.Add(OrderViewModel.MapToViewModel(order));
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
