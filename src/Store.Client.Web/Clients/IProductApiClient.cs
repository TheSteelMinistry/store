using Store.Shared.Products;

namespace Store.Client.Web.Clients;

public interface IProductApiClient
{
    Task<ProductResponse.Create?> CreateProductAsync();
    Task<ProductResponse.Index?> GetProductsAsync();
    Task AddProductToCartErrorAsync();
}
