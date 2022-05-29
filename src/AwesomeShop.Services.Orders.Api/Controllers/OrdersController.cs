using AwesomeShop.Services.Orders.Domain.Commands.Add;
using AwesomeShop.Services.Orders.Domain.Queries.Orders.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdRequest(id: id));

            if (result.StatusCode.Equals(HttpStatusCode.NotFound))
                return NotFound(result);

            if (result.StatusCode.Equals(HttpStatusCode.InternalServerError))
                return StatusCode(500, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(AddOrderRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.StatusCode.Equals(HttpStatusCode.InternalServerError))
                return StatusCode(500, result);

            return Ok(result);
        }
    }
}
