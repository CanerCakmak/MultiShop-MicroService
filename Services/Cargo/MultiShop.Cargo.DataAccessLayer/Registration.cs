using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.DataAccessLayer.Context;

namespace MultiShop.Cargo.DataAccessLayer;

public static class Registration
{
    public static void AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CargoContext>();
    }
}
