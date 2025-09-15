using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering
{
    public class CreateOrderingCommandRequest : IRequest
    {
        public string UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
