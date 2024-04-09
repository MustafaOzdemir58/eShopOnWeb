using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class OrderByIdSpecification:Specification<Order>
{
    public OrderByIdSpecification(int id)
    {
        Query.Where(x => x.Id == id).Include(x=>x.OrderItems);
    }
}
