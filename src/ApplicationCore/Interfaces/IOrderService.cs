using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
    Task<List<Order>> GetAllOrdersAsync(string userId);
    Task ApproveOrderAsync(int id);
    Task<Order> GetOrderByIdAsync(int id); 
}
