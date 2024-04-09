using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderItemGetByIdResponse : BaseResponse
{
    public OrderItemGetByIdResponse(Guid correlationId) : base(correlationId)
    {

    }
    public OrderDto Order { get; set; } = new OrderDto();
}
