using AutoMapper;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAdressById;

public class GetAdressByIdQueryHandler
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public GetAdressByIdQueryHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAdressByIdQueryResponse> Handle(GetAdressByIdQueryRequest request)
    {
        Address address = await _repository.GetByIdAsync(request.ID);

        return _mapper.Map<GetAdressByIdQueryResponse>(address);
    }

}
