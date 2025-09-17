using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework;

public class EFCargoOperationRepository : GenericRepository<CargoOperation>, ICargoOperationRepository
{
    private readonly CargoContext _context;
    public EFCargoOperationRepository(CargoContext context) : base(context)
    {
        _context = context;
    }
}
