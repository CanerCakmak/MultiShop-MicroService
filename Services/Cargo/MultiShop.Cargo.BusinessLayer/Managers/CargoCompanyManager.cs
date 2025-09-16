using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.BusinessLayer.Managers;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly ICargoCompanyRepository _cargoCompanyRepository;

    public CargoCompanyManager(ICargoCompanyRepository cargoCompanyRepository)
    {
        _cargoCompanyRepository = cargoCompanyRepository;
    }

    public async Task TAddAsync(CargoCompany entity)
    {
        await _cargoCompanyRepository.AddAsync(entity);
    }

    public async Task TAddRangeAsync(IEnumerable<CargoCompany> entities)
    {
        await _cargoCompanyRepository.AddRangeAsync(entities);
    }

    public async Task TDeleteAsync(CargoCompany entity)
    {
        await _cargoCompanyRepository.DeleteAsync(entity);
    }

    public async Task TDeleteByIdAsync(int id)
    {
        await _cargoCompanyRepository.DeleteByIdAsync(id);
    }

    public async Task TDeleteRangeAsync(IEnumerable<CargoCompany> entities)
    {
        await _cargoCompanyRepository.DeleteRangeAsync(entities);
    }

    public async Task<List<CargoCompany>> TGetAllAsync()
    {
        return await _cargoCompanyRepository.GetAllAsync();
    }

    public async Task<CargoCompany> TGetByIdAsync(int id)
    {
        return await _cargoCompanyRepository.GetByIdAsync(id);
    }

    public async Task TUpdateAsync(CargoCompany entity)
    {
        await _cargoCompanyRepository.UpdateAsync(entity);
    }

    public async Task TUpdateRangeAsync(IEnumerable<CargoCompany> entities)
    {
        await _cargoCompanyRepository.UpdateRangeAsync(entities);
    }
}
