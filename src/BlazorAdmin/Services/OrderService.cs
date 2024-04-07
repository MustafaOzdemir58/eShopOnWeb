﻿using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(HttpService httpService, ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<OrderItem>> ListPaged(int pageSize)
    {
        _logger.LogInformation("Fetching orders from API.");
        var orderListTask = _httpService.HttpGet<PagedOrderItemResponse>($"orders?PageSize=10");
        await Task.WhenAll(orderListTask);
        var items = orderListTask.Result.Orders;
        return items;
    }
    public async Task<List<OrderItem>> List()
    {
        _logger.LogInformation("Fetching order items from API.");
        var orderListTask = _httpService.HttpGet<PagedOrderItemResponse>($"orders");
        await Task.WhenAll(orderListTask);
        var items = orderListTask.Result.Orders;
        return items;
    }
}
