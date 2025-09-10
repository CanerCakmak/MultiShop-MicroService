using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        public UpdateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderingID);
            if (value != null)
            {
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }

            return Unit.Value;
        }
    }
}
