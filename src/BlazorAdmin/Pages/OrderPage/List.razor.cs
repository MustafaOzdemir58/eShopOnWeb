using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Pages.CatalogItemPage;
using BlazorAdmin.Services;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAdmin.Pages.OrderPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }
    [Microsoft.AspNetCore.Components.Inject]
    NavigationManager NavigationManager { get; set; }

    private List<OrderItem> orders = new List<OrderItem>();
    private Details DetailsComponent { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            orders = await OrderService.List();
            CallRequestRefresh();
        }
       

        await base.OnAfterRenderAsync(firstRender);
    }
 
    private async Task DetailClick(int id)
    {
        DetailsComponent.Open(id); 
    }
}
