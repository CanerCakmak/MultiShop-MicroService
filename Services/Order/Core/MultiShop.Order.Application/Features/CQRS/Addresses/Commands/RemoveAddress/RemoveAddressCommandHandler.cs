using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.RemoveAddress;

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public RemoveAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAddressCommandRequest request)
    {
        var address = await _repository.GetByIdAsync(request.ID);

        if (address != null)
        {
            await _repository.DeleteAsync(address);
        }
    }
}
