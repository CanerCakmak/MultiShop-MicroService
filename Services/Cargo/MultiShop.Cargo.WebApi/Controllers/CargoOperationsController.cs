using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.DTOs.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var values = await _cargoOperationService.TGetAllAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var value = await _cargoOperationService.TGetByIdAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCargoOperationDto value)
    {
        var Value = new CargoOperation
        {
            Barcode = value.Barcode,
            Description = value.Description,
            OperationDate = value.OperationDate
        };

        await _cargoOperationService.TAddAsync(Value);
        return Ok("Başarıyla eklendi.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(UpdateCargoOperationDto value)
    {
        var Value = new CargoOperation
        {
            ID = value.ID,
            Barcode = value.Barcode,
            Description = value.Description,
            OperationDate = value.OperationDate
        };

        await _cargoOperationService.TUpdateAsync(Value);
        return Ok("Başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _cargoOperationService.TDeleteByIdAsync(id);
        return Ok("Başarıyla Silindi.");
    }

}
