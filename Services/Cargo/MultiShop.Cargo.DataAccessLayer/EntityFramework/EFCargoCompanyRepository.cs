using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework;

public class EFCargoCompanyRepository : GenericRepository<CargoCompany>, ICargoCompanyRepository
{
    private readonly CargoContext _context;
    public EFCargoCompanyRepository(CargoContext context) : base(context)
    {
        _context = context;
    }
}
