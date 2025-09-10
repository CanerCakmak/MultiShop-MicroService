using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.RemoveAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAddressById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.RemoveOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetAllOrderDetails;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetOrderDetailById;
using System.Reflection;

namespace MultiShop.Order.Application
{
    public static class Registration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAllAddressesQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();

            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetAllOrderDetailsQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();

        }
    }
}
