using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryRequest
    {
        public int ID { get; set; }

        public GetOrderDetailByIdQueryRequest(int id)
        {
            ID = id;
        }
    }
}
