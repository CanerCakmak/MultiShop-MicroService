using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework;

public class EFCargoSenderCustomerRepository : GenericRepository<CargoSenderCustomer>, ICargoSenderCustomerRepository
{
    private readonly CargoContext _context;
    public EFCargoSenderCustomerRepository(CargoContext context) : base(context)
    {
        _context = context;
    }
}
