using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.RemoveOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetAllOrderings;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetOrderingById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderings(GetAllOrderingsQueryRequest query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var result = await _mediator.Send(new GetOrderingByIdQueryRequest(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommandRequest command)
        {
            var result = await _mediator.Send(command);

            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommandRequest command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdering(RemoveOrderingCommandRequest command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
