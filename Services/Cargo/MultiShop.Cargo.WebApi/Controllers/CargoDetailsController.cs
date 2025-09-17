using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.DTOs.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var values = await _cargoDetailService.TGetAllAsync();

        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var value = await _cargoDetailService.TGetByIdAsync(id);

        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCargoDetailDto cargoDetail)
    {
        CargoDetail CargoDetail = new CargoDetail
        {
            Barcode = cargoDetail.Barcode,
            CargoCompanyID = cargoDetail.CargoCompanyID,
            SenderCustomer = cargoDetail.SenderCustomer,
            ReceiverCustomer = cargoDetail.ReceiverCustomer
        };

        await _cargoDetailService.TAddAsync(CargoDetail);

        return Ok("Başarıyla eklendi.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCargoDetailDto cargoDetail)
    {
        CargoDetail CargoDetail = new CargoDetail
        {
            ID = cargoDetail.ID,
            Barcode = cargoDetail.Barcode,
            CargoCompanyID = cargoDetail.CargoCompanyID,
            SenderCustomer = cargoDetail.SenderCustomer,
            ReceiverCustomer = cargoDetail.ReceiverCustomer
        };
        await _cargoDetailService.TUpdateAsync(CargoDetail);
        return Ok("Başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cargoDetailService.TDeleteByIdAsync(id);
        return Ok("Başarıyla silindi.");
    }

}
