using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdQueryRequest
    {
        public int ID { get; set; }

        public GetAddressByIdQueryRequest(int id)
        {
            ID = id;
        }
    }
}
