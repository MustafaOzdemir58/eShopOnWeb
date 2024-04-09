using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class OrderItem
{
    public int OrderId { get; set; }
    public OrderItemBuyer Buyer { get; set; }
    public List<OrderedItem> OrderItems { get; set; }
    public OrderItemShippingAddress ShippingAddress { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderItemStatus Status { get; set; }
    
}

public class OrderedItem
{
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
}

public class OrderItemBuyer
{
    public string BuyerName { get; set; }
}
public class OrderItemShippingAddress
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
public enum OrderItemStatus :byte
{
    Pending,
    Approved
}
