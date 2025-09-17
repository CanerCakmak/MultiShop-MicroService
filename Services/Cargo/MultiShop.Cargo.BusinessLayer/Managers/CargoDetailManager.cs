using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.BusinessLayer.Managers;

public class CargoDetailManager : ICargoDetailService
{
    private readonly ICargoDetailRepository _cargoDetailRepository;

    public CargoDetailManager(ICargoDetailRepository cargoDetailRepository)
    {
        _cargoDetailRepository = cargoDetailRepository;
    }

    public async Task TAddAsync(CargoDetail entity)
    {
        await _cargoDetailRepository.AddAsync(entity);
    }

    public async Task TAddRangeAsync(IEnumerable<CargoDetail> entities)
    {
        await _cargoDetailRepository.AddRangeAsync(entities);
    }

    public async Task TDeleteAsync(CargoDetail entity)
    {
        await _cargoDetailRepository.DeleteAsync(entity);
    }

    public async Task TDeleteByIdAsync(int id)
    {
        await _cargoDetailRepository.DeleteByIdAsync(id);
    }

    public async Task TDeleteRangeAsync(IEnumerable<CargoDetail> entities)
    {
        await _cargoDetailRepository.DeleteRangeAsync(entities);
    }

    public async Task<List<CargoDetail>> TGetAllAsync()
    {
        return await _cargoDetailRepository.GetAllAsync();
    }

    public async Task<CargoDetail> TGetByIdAsync(int id)
    {
        return await _cargoDetailRepository.GetByIdAsync(id);
    }

    public async Task TUpdateAsync(CargoDetail entity)
    {
        await _cargoDetailRepository.UpdateAsync(entity);
    }

    public async Task TUpdateRangeAsync(IEnumerable<CargoDetail> entities)
    {
        await _cargoDetailRepository.UpdateRangeAsync(entities);
    }
}
