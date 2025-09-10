using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateOrderDetailCommandRequest request)
        {
            var orderDetail = await _repository.GetByIdAsync(request.OrderDetailID);
            if (orderDetail != null)
            {
                orderDetail = _mapper.Map<OrderDetail>(request);
                await _repository.UpdateAsync(orderDetail);
            }
        }
    }
}
