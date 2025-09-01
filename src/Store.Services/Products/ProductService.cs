using System;
using Microsoft.Extensions.Logging;
using Store.Domain.Products;
using Store.Fakers.Products;
using Store.Shared.Products;

namespace Store.Services.Products;

public sealed class ProductService : IProductService
{
    private readonly ProductFaker _productFaker = new();
    private readonly ILogger<ProductService> _logger;
    private IList<Product> _products = new List<Product>();

    public ProductService(ILogger<ProductService> logger)
    {
        _logger = logger;
        _products = _productFaker.Generate(25);
    }

    public Task<ProductResponse.Create> CreateProductAsync()
    {
        _logger.LogInformation("Creating a new product.");
        Product product = _productFaker.Generate(1).First();

        _products.Add(product);

        _logger.LogInformation("Product created with ID: {ProductId}", product.Id);

        return Task.FromResult(new ProductResponse.Create()
        {
            Id = product.Id
        });
    }

    public Task<ProductResponse.Index> GetProductsAsync(ProductRequest.Index request)
    {
        _logger.LogInformation("Retrieving all products. Total count: {ProductCount}", _products.Count);
        return Task.FromResult(new ProductResponse.Index()
        {
            AmountOfItems = _products.Count,
            Products = _products.Select(p => new ProductDto.Index()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            })
            .ToList()
        });
    }
}
