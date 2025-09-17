using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.BusinessLayer.Managers;

public class CargoOperationManager : ICargoOperationService
{
    private readonly ICargoOperationRepository _cargoOperationRepository;

    public CargoOperationManager(ICargoOperationRepository cargoOperationRepository)
    {
        _cargoOperationRepository = cargoOperationRepository;
    }

    public async Task TAddAsync(CargoOperation entity)
    {
        await _cargoOperationRepository.AddAsync(entity);
    }

    public async Task TAddRangeAsync(IEnumerable<CargoOperation> entities)
    {
        await _cargoOperationRepository.AddRangeAsync(entities);
    }

    public async Task TDeleteAsync(CargoOperation entity)
    {
        await _cargoOperationRepository.DeleteAsync(entity);
    }

    public async Task TDeleteByIdAsync(int id)
    {
        await _cargoOperationRepository.DeleteByIdAsync(id);
    }

    public async Task TDeleteRangeAsync(IEnumerable<CargoOperation> entities)
    {
        await _cargoOperationRepository.DeleteRangeAsync(entities);
    }

    public async Task<List<CargoOperation>> TGetAllAsync()
    {
        return await _cargoOperationRepository.GetAllAsync();
    }

    public async Task<CargoOperation> TGetByIdAsync(int id)
    {
        return await _cargoOperationRepository.GetByIdAsync(id);
    }

    public async Task TUpdateAsync(CargoOperation entity)
    {
        await _cargoOperationRepository.UpdateAsync(entity);
    }

    public async Task TUpdateRangeAsync(IEnumerable<CargoOperation> entities)
    {
        await _cargoOperationRepository.UpdateRangeAsync(entities);
    }
}
