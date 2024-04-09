using System;
using Ardalis.GuardClauses;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderListItemRequest : BaseRequest
{
    public int PageSize { get; init; }
    public int PageIndex { get; init; }
    public string? UserId { get; init; }
    public OrderListItemRequest()
    {

    }

    public OrderListItemRequest(int? pageSize, int? pageIndex, string? userId)
    {
        PageSize = pageSize ?? 0;
        PageIndex = pageIndex ?? 0; 
        userId = userId ?? string.Empty; 
    } 
}
