using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAddressCommandRequest request)
    {
        Address address = await _repository.GetByIdAsync(request.AddressID);

        if (address != null)
        {
            _mapper.Map(request, address);
            await _repository.UpdateAsync(address);
        }
    }
}
