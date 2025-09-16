using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework;

public class EFCargoDetailRepository : GenericRepository<CargoDetail>, ICargoDetailRepository
{
    private readonly CargoContext _context;
    public EFCargoDetailRepository(CargoContext context) : base(context)
    {
        _context = context;
    }
}
