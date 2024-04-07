using System.Linq;
using System.Threading.Tasks;
using Ardalis.Result;
using Azure.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderListPageEndpoint : IEndpoint<AspNetCore.Http.IResult, OrderListItemRequest, IRepository<Order>>
{
    private readonly IOrderService _orderService;
    private readonly IReadRepository<Buyer> _buyerRepository;

    public OrderListPageEndpoint(IOrderService orderService, IReadRepository<Buyer> buyerRepository)
    {
        _orderService = orderService;
        _buyerRepository = buyerRepository;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders", async (int? pageSize, int? pageIndex, string? buyerId, IRepository<Order> orderRepository) =>
        {
            return await HandleAsync(new OrderListItemRequest(pageSize, pageIndex, buyerId), orderRepository);
        }).Produces<OrderListItemResponse>()
             .WithTags("OrderItemEndpoints");

    }

    public async Task<AspNetCore.Http.IResult> HandleAsync(OrderListItemRequest request1, IRepository<Order> request2)
    {

        await Task.Delay(1000);
        var response = new OrderListItemResponse(request1.CorrelationId());
        var orders = await _orderService.GetAllOrdersAsync(request1.UserId);
        response.Orders.AddRange(orders.Select(x => new OrderDto
        {
            OrderId = x.Id,
            Buyer = new OrderItemBuyerDto
            {
                BuyerId = x.BuyerId,
                BuyerName = x.BuyerId

            },
            OrderDate = x.OrderDate,
            OrderItems = x.OrderItems.Select(y => new OrderItemDto
            {
                ProductName = y.ItemOrdered.ProductName,
                UnitPrice = y.UnitPrice,
                Units = y.Units,
                PictureUrl = y.ItemOrdered.PictureUri,

            }).ToList(),
            TotalPrice = x.Total(),
            Status=x.Status.ToString(),

        })) ;
        return Results.Ok(response);

    }
}
