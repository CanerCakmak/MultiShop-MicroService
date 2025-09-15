using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.RemoveAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAddressById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAllAddressesQueryHandler _getAllAddressesQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(RemoveAddressCommandHandler removeAdressCommandHandler, GetAllAddressesQueryHandler getAllAddressesQueryHandler, GetAddressByIdQueryHandler getAdressByIdQueryHandler, CreateAddressCommandHandler createAdressCommandHandler, UpdateAddressCommandHandler updateAdressCommandHandler)
        {
            _removeAddressCommandHandler = removeAdressCommandHandler;
            _getAllAddressesQueryHandler = getAllAddressesQueryHandler;
            _getAddressByIdQueryHandler = getAdressByIdQueryHandler;
            _createAddressCommandHandler = createAdressCommandHandler;
            _updateAddressCommandHandler = updateAdressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            List<GetAllAddressesQueryResponse> values = await _getAllAddressesQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            GetAddressByIdQueryResponse value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQueryRequest(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommandRequest request)
        {
            await _createAddressCommandHandler.Handle(request);
            return Ok("Adres bilgisi başarıyla oluşturuldu!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest request)
        {
            await _updateAddressCommandHandler.Handle(request);
            return Ok("Adres bilgisi başarıyla güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommandRequest(id));
            return Ok("Adres bilgisi başarıyla silindi!");
        }
    }
}
