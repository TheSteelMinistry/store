using MudBlazor;
using Store.Shared.Products;

namespace Store.Client.Web.Clients;

public sealed class ProductApiClient : IProductApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ISnackbar _snackbar;

    public ProductApiClient(HttpClient httpClient, ISnackbar snackbar)
    {
        _httpClient = httpClient;
        _snackbar = snackbar;
    }

    public async Task AddProductToCartErrorAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("product/cart/error");

        if (!response.IsSuccessStatusCode)
        {
            _snackbar.Add("Could not add product to cart", Severity.Error);
            return;
        }

        return;
    }

    public async Task<ProductResponse.Create?> CreateProductAsync()
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("product", new { });

        if (!response.IsSuccessStatusCode)
        {
            _snackbar.Add("Could not create product", Severity.Error);
            return null;
        }

        ProductResponse.Create? result = await response.Content.ReadFromJsonAsync<ProductResponse.Create>();
        return result;
    }


    public async Task<ProductResponse.Index?> GetProductsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("product");

        if (!response.IsSuccessStatusCode)
        {
            _snackbar.Add("Could not retrieve products", Severity.Error);
            return null;
        }

        ProductResponse.Index? result = await response.Content.ReadFromJsonAsync<ProductResponse.Index>();
        return result;
    }
}
