using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAdressById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Command.CreateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Command.UpdateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetAllOrderDetails;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetOrderDetailById;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Address, CreateAddressCommandRequest>().ReverseMap();
            CreateMap<Address, UpdateAddressCommandRequest>().ReverseMap();
            CreateMap<Address, GetAddressByIdQueryResponse>().ReverseMap();
            CreateMap<Address, GetAllAddressesQueryResponse>().ReverseMap();

            CreateMap<OrderDetail, CreateOrderDetailCommandRequest>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommandRequest>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailByIdQueryResponse>().ReverseMap();
            CreateMap<OrderDetail, GetAllOrderDetailsQueryResponse>().ReverseMap();
        }
    }
}
