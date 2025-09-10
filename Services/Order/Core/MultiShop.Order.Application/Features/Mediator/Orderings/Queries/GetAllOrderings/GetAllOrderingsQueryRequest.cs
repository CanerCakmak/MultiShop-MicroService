using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetAllOrderings
{
    public class GetAllOrderingsQueryRequest : IRequest<List<GetAllOrderingsQueryResponse>>
    {
    }
}
