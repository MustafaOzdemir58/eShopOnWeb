using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ApproveOrderResponse :BaseResponse
{
    public ApproveOrderResponse(Guid correlationId) : base(correlationId)
    {
            
    }
    public bool Result { get; set; }
}
