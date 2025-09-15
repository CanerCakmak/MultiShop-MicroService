using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.RemoveOrdering
{
    public class RemoveOrderingCommandRequest : IRequest
    {
        public int ID { get; set; }

        public RemoveOrderingCommandRequest(int id)
        {
            ID = id;
        }
    }
}
