using System;

namespace Store.Shared.Products;

public abstract class ProductResponse
{
    public sealed class Index
    {
        public int AmountOfItems { get; set; }
        public IReadOnlyList<ProductDto.Index> Products { get; set; } = Array.Empty<ProductDto.Index>();
    }

    public sealed class Create
    {
        public int Id { get; set; }
    }
}
