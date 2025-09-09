using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Command.RemoveOrderDetail
{
    public class RemoveOrderDetailCommandRequest
    {
        public int ID { get; set; }
        public RemoveOrderDetailCommandRequest(int id)
        {
            ID = id;
        }

    }
}
