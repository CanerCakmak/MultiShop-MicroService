using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQueryHandler 
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public GetAllAddressesQueryHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetAllAddressesQueryResponse>> Handle()
    {
        List<Address> addresses = await _repository.GetAllAsync();

        return _mapper.Map<List<GetAllAddressesQueryResponse>>(addresses);
    }
}
