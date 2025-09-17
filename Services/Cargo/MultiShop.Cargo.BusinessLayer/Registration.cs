using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Managers;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using MultiShop.Cargo.DataAccessLayer.Interfaces;

namespace MultiShop.Cargo.BusinessLayer;

public static class Registration
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<ICargoCompanyRepository, EFCargoCompanyRepository>();
        services.AddScoped<ICargoCompanyService, CargoCompanyManager>();

        services.AddScoped<ICargoDetailRepository, EFCargoDetailRepository>();
        services.AddScoped<ICargoDetailService, CargoDetailManager>();

        services.AddScoped<ICargoSenderCustomerRepository, EFCargoSenderCustomerRepository>();
        services.AddScoped<ICargoSenderCustomerService, CargoSenderCustomerManager>();

        services.AddScoped<ICargoOperationRepository, EFCargoOperationRepository>();
        services.AddScoped<ICargoOperationService, CargoOperationManager>();

    }
}
