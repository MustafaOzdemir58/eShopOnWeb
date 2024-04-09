using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ApproveOrderEndpoint : IEndpoint<AspNetCore.Http.IResult, ApproveOrderRequest>
{
    private readonly IOrderService _orderService;

    public ApproveOrderEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/orders/approve", async (ApproveOrderRequest request) =>
        {
            return await HandleAsync(request);

        }).Produces<ApproveOrderResponse>().WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(ApproveOrderRequest request)
    {
        await Task.Delay(1000);
        var response = new ApproveOrderResponse(request.CorrelationId());
        await _orderService.ApproveOrderAsync(request.Id);
        response.Result = true;
        return Results.Ok(response); 
    }
}
