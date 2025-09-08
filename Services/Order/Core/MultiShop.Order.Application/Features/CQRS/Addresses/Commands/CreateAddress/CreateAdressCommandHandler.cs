using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.CreateAddress
{
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAdressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAdressCommandRequest request)
        {
            
            await _repository.CreateAsync(new Address
            {
                UserID = request.UserID,
                City = request.City,
                Detail = request.Detail,
                District = request.District
            });
        }





    }
}


