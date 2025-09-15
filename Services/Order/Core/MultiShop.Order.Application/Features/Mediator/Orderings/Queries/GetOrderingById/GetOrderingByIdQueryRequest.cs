using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetOrderingById
{
    public class GetOrderingByIdQueryRequest : IRequest<GetOrderingByIdQueryResponse>
    {
        public int ID { get; set; }

        public GetOrderingByIdQueryRequest(int id)
        {
            ID = id;
        }
    }
}
