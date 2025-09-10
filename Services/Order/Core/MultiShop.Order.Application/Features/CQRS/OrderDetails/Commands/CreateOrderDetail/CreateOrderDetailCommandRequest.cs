using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommandRequest
    {

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public decimal ProductTotalPrice { get; set; }
        public int OrderingID { get; set; }
    }
}
