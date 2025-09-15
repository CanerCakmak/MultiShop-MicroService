using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.RemoveOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetOrderDetailById;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetAllOrderDetails;
using Microsoft.AspNetCore.Authorization;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetAllOrderDetailsQueryHandler _getAllOrderDetailsQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(RemoveOrderDetailCommandHandler removeAdressCommandHandler, GetAllOrderDetailsQueryHandler getAllOrderDetailsQueryHandler, GetOrderDetailByIdQueryHandler getAdressByIdQueryHandler, CreateOrderDetailCommandHandler createAdressCommandHandler, UpdateOrderDetailCommandHandler updateAdressCommandHandler)
        {
            _removeOrderDetailCommandHandler = removeAdressCommandHandler;
            _getAllOrderDetailsQueryHandler = getAllOrderDetailsQueryHandler;
            _getOrderDetailByIdQueryHandler = getAdressByIdQueryHandler;
            _createOrderDetailCommandHandler = createAdressCommandHandler;
            _updateOrderDetailCommandHandler = updateAdressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetailes()
        {
            List<GetAllOrderDetailsQueryResponse> values = await _getAllOrderDetailsQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            GetOrderDetailByIdQueryResponse value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQueryRequest(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommandRequest request)
        {
            await _createOrderDetailCommandHandler.Handle(request);
            return Ok("Sipariş detayı başarıyla oluşturuldu!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommandRequest request)
        {
            await _updateOrderDetailCommandHandler.Handle(request);
            return Ok("Sipariş detayı başarıyla güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommandRequest(id));
            return Ok("Sipariş detayı başarıyla silindi!");
        }
    }
}
