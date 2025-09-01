using Microsoft.AspNetCore.Components;
using Store.Client.Web.Clients;
using Store.Shared.Products;

namespace Store.Client.Web.Products;

public partial class Index
{
    [Inject] public IProductApiClient ProductApi { get; set; } = default!;

    private bool _loading;
    private IEnumerable<ProductDto.Index> _products = Array.Empty<ProductDto.Index>();

    protected override async Task OnInitializedAsync()
    {
        await FetchProducts();
    }

    private void ToggleLoading()
    {
        _loading = !_loading;
    }

    private async Task FetchProducts()
    {
        ToggleLoading();

        ProductResponse.Index? response = await ProductApi.GetProductsAsync();

        if (response is null)
        {
            return;
        }

        _products = response.Products;

        ToggleLoading();
    }

    private async Task AddProductToCartError()
    {
        await ProductApi.AddProductToCartErrorAsync();
    }
}