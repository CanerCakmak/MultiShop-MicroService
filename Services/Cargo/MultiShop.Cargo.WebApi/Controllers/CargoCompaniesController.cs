using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.DTOs.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompaniesController(ICargoCompanyService CargoCompanyService)
    {
        _cargoCompanyService = CargoCompanyService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var values = await _cargoCompanyService.TGetAllAsync();

        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var value = await _cargoCompanyService.TGetByIdAsync(id);

        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCargoCompanyDto value)
    {
        CargoCompany cargoCompany = new CargoCompany
        {
            Name = value.Name,
        };

        await _cargoCompanyService.TAddAsync(cargoCompany);

        return Ok("Başarıyla eklendi.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(UpdateCargoCompanyDto value)
    {
        CargoCompany cargoCompany = new CargoCompany
        {
            ID = value.ID,
            Name = value.Name,
        };
        await _cargoCompanyService.TUpdateAsync(cargoCompany);

        return Ok("Başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _cargoCompanyService.TDeleteByIdAsync(id);
        return Ok("Başarıyla silindi.");
    }
}
