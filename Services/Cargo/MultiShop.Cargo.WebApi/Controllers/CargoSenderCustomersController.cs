using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.DTOs.CargoSenderCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoSenderCustomersController : ControllerBase
{
    private readonly ICargoSenderCustomerService _cargoSenderCustomerService;

    public CargoSenderCustomersController(ICargoSenderCustomerService cargoSenderCustomerService)
    {
        _cargoSenderCustomerService = cargoSenderCustomerService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var values = await _cargoSenderCustomerService.TGetAllAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var value = await _cargoSenderCustomerService.TGetByIdAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCargoSenderCustomerDto valueDto)
    {
        var value = new CargoSenderCustomer
        {
            Name = valueDto.Name,
            Surname = valueDto.Surname,
            Address = valueDto.Address,
            Phone = valueDto.Phone,
            Email = valueDto.Email,
            City = valueDto.City,
            District = valueDto.District
        };
        await _cargoSenderCustomerService.TAddAsync(value);
        return Ok("Başarıyla eklendi.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(UpdateCargoSenderCustomerDto valueDto)
    {
        var value = new CargoSenderCustomer
        {
            ID = valueDto.ID,
            Name = valueDto.Name,
            Surname = valueDto.Surname,
            Address = valueDto.Address,
            Phone = valueDto.Phone,
            Email = valueDto.Email,
            City = valueDto.City,
            District = valueDto.District
        };
        await _cargoSenderCustomerService.TUpdateAsync(value);
        return Ok("Başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _cargoSenderCustomerService.TDeleteByIdAsync(id);
        return Ok("Başarıyla silindi.");
    }

}
