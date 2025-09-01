using System;
using Ardalis.GuardClauses;
using Store.Domain.Common;

namespace Store.Domain.Products;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; }

    public Product(string name, decimal price, string imageUrl)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
        ImageUrl = Guard.Against.NullOrEmpty(imageUrl, nameof(imageUrl));
    }

    public void Update(string name, decimal price, string imageUrl)
    {
        UpdateName(name);
        UpdatePrice(price);
        UpdateImageUrl(imageUrl);
    }

    private void UpdateName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }

    private void UpdatePrice(decimal price)
    {
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
    }

    private void UpdateImageUrl(string imageUrl)
    {
        ImageUrl = Guard.Against.NullOrEmpty(imageUrl, nameof(imageUrl));
    }
}