using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.BusinessLayer.Managers;

public class CargoSenderCustomerManager : ICargoSenderCustomerService
{
    private readonly ICargoSenderCustomerRepository _cargoSenderCustomerRepository;

    public CargoSenderCustomerManager(ICargoSenderCustomerRepository cargoSenderCustomerRepository)
    {
        _cargoSenderCustomerRepository = cargoSenderCustomerRepository;
    }

    public async Task TAddAsync(CargoSenderCustomer entity)
    {
        await _cargoSenderCustomerRepository.AddAsync(entity);
    }

    public async Task TAddRangeAsync(IEnumerable<CargoSenderCustomer> entities)
    {
        await _cargoSenderCustomerRepository.AddRangeAsync(entities);
    }

    public async Task TDeleteAsync(CargoSenderCustomer entity)
    {
        await _cargoSenderCustomerRepository.DeleteAsync(entity);
    }

    public async Task TDeleteByIdAsync(int id)
    {
        await _cargoSenderCustomerRepository.DeleteByIdAsync(id);
    }

    public async Task TDeleteRangeAsync(IEnumerable<CargoSenderCustomer> entities)
    {
        await _cargoSenderCustomerRepository.DeleteRangeAsync(entities);
    }

    public async Task<List<CargoSenderCustomer>> TGetAllAsync()
    {
        return await _cargoSenderCustomerRepository.GetAllAsync();
    }

    public async Task<CargoSenderCustomer> TGetByIdAsync(int id)
    {
        return await _cargoSenderCustomerRepository.GetByIdAsync(id);
    }

    public async Task TUpdateAsync(CargoSenderCustomer entity)
    {
        await _cargoSenderCustomerRepository.UpdateAsync(entity);
    }

    public async Task TUpdateRangeAsync(IEnumerable<CargoSenderCustomer> entities)
    {
        await _cargoSenderCustomerRepository.UpdateRangeAsync(entities);
    }
}
