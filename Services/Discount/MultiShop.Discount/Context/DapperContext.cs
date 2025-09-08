using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database = MultiShopDiscountDb; integrated security= true; Trust Server Certificate = true;");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<DiscountCoupon> Coupons{ get; set; }
        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);


    }
}
