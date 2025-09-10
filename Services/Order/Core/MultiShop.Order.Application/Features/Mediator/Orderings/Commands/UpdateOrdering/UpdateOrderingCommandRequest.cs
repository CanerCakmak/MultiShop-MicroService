using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering
{
    public class UpdateOrderingCommandRequest : IRequest
    {
        public int OrderingID { get; set; }
        public string UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
