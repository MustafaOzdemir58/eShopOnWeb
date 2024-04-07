using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{
    public OrderDto()
    {
        this.OrderItems = new List<OrderItemDto>();
    }
    public int OrderId { get; set; }
    public OrderItemBuyerDto Buyer { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
}
public class OrderItemBuyerDto
{
    public string BuyerId { get; set; }
    public string BuyerName { get; set; }
}
public class OrderItemDto
{
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
    public string ProductName { get;  set; }
    public string PictureUrl { get; set; }
}
