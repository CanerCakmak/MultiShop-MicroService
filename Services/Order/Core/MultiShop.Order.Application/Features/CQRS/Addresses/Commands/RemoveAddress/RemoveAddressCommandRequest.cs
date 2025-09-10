using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.RemoveAddress
{
    public class RemoveAddressCommandRequest
    {
        public int ID { get; set; }

        public RemoveAddressCommandRequest(int id)
        {
            ID = id;
        }
    }
}
