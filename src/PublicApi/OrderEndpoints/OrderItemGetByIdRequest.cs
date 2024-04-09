namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderItemGetByIdRequest : BaseRequest
{
    public int Id { get; init; }
    public OrderItemGetByIdRequest(int id)
    {
        Id = id;
    }
} 
