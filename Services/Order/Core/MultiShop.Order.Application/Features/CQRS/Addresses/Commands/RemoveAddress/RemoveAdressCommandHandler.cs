using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.RemoveAddress;

public class RemoveAdressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public RemoveAdressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAdressCommandRequest request)
    {
        var address = await _repository.GetByIdAsync(request.ID);

        if (address != null)
        {
            await _repository.DeleteAsync(address);
        }
    }
}
