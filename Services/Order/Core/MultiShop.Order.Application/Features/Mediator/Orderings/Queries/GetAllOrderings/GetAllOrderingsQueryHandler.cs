using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetAllOrderings
{
    public class GetAllOrderingsQueryHandler : IRequestHandler<GetAllOrderingsQueryRequest, List<GetAllOrderingsQueryResponse>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetAllOrderingsQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrderingsQueryResponse>> Handle(GetAllOrderingsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Ordering> values = await _repository.GetAllAsync();

            return _mapper.Map<List<GetAllOrderingsQueryResponse>>(values);
        }
    }
}
