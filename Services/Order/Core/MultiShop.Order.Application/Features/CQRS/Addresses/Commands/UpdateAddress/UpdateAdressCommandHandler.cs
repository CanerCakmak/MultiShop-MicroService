using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.UpdateAddress;

public class UpdateAdressCommandHandler
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public UpdateAdressCommandHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAdressCommandRequest request)
    {
        Address address = await _repository.GetByIdAsync(request.AddressID);

        if (address != null)
        {
            Address updatedAddress = _mapper.Map<Address>(request);
            await _repository.UpdateAsync(updatedAddress);
        }
    }
}
