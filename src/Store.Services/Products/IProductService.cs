using System;
using Store.Shared.Products;

namespace Store.Services.Products;

public interface IProductService
{
    Task<ProductResponse.Index> GetProductsAsync(ProductRequest.Index request);
    Task<ProductResponse.Create> CreateProductAsync();
}
