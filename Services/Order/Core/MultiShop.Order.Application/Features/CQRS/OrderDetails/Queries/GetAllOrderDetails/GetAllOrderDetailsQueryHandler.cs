using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;
        public GetAllOrderDetailsQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllOrderDetailsQueryResponse>> Handle()
        {
            var orderDetails = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllOrderDetailsQueryResponse>>(orderDetails);
        }
    }
}
