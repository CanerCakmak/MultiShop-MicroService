using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAdressById
{
    public class GetAdressByIdQueryRequest
    {
        public int ID { get; set; }

        public GetAdressByIdQueryRequest(int id)
        {
            ID = id;
        }
    }
}
