using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.DataAccessLayer.Context
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441; Database = MultiShopCargoDB; User ID=sa;Password=123456aA.; Trust Server Certificate = true;");
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoSenderCustomer> CargoSenderCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
