using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAddressById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetAllOrderDetails;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetOrderDetailById;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateAddressCommandRequest, Address>().ReverseMap();
            CreateMap<UpdateAddressCommandRequest, Address>().ReverseMap();
            CreateMap<GetAddressByIdQueryResponse, Address>().ReverseMap();
            CreateMap<GetAllAddressesQueryResponse, Address>().ReverseMap();

            CreateMap<OrderDetail, CreateOrderDetailCommandRequest>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommandRequest>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailByIdQueryResponse>().ReverseMap();
            CreateMap<OrderDetail, GetAllOrderDetailsQueryResponse>().ReverseMap();
        }
    }
}
