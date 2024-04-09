using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderItemGetByIdEndpoint : IEndpoint<AspNetCore.Http.IResult, OrderItemGetByIdRequest>
{
    private readonly IOrderService _orderService;

    public OrderItemGetByIdEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{id}", async (int id) =>
        {
            return await HandleAsync(new OrderItemGetByIdRequest(id));
        }).Produces<OrderItemGetByIdResponse>().WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(OrderItemGetByIdRequest request)
    {
        await Task.Delay(1000);
        var orderResponse = new OrderItemGetByIdResponse(request.CorrelationId());
        var order = await _orderService.GetOrderByIdAsync(request.Id);
        if (order is null) return Results.NotFound();
        orderResponse.Order = new OrderDto
        {
            Buyer = new OrderItemBuyerDto
            {
                BuyerId = order.BuyerId,
                BuyerName = order.BuyerId
            },
            OrderDate = order.OrderDate,
            OrderId = order.Id,
            Status = (OrderDtoStatus)order.Status,
            TotalPrice = order.Total(),
            ShippingAddress=new OrderShippingAddressDto
            {
                City=order.ShipToAddress.City,
                Country=order.ShipToAddress.Country,
                Street=order.ShipToAddress.Street
            },
            OrderItems = order.OrderItems.Select(x => new OrderItemDto
            {
                PictureUrl = x.ItemOrdered.PictureUri,
                ProductName = x.ItemOrdered.ProductName,
                UnitPrice = x.UnitPrice,
                Units = x.Units,
            }).ToList()

        };
        return Results.Ok(orderResponse);
    }
}
