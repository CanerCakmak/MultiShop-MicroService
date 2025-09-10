using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetOrderingById
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQueryRequest, GetOrderingByIdQueryResponse>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderingByIdQueryResponse> Handle(GetOrderingByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<GetOrderingByIdQueryResponse>(value);
        }
    }
}
