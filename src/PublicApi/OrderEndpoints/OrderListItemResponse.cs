using System;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderListItemResponse: BaseResponse
{
    public OrderListItemResponse(Guid correlationId) :base(correlationId)
    {
            
    }
    public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    public int PageCount { get; set; }
}
