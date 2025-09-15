using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryResponse
    {
        public int AddressID { get; set; }

        public string UserID { get; set; }

        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
