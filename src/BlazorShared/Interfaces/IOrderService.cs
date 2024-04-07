using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;
public interface IOrderService
{
    Task<List<OrderItem>> ListPaged(int pageSize);
    Task<List<OrderItem>> List();
}
