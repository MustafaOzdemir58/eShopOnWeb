using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
internal class OrderSpecification : Specification<Order>
{
    public OrderSpecification(string buyerId)
    {
        if (!string.IsNullOrWhiteSpace(buyerId))
        {
            Query.Where(x => x.BuyerId == buyerId);
        }
        Query.Include(x => x.OrderItems);
    }
}
