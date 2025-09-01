using System;

namespace Store.Shared.Products;

public abstract class ProductDto
{
    public sealed class Index
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = default!;
    }

    public sealed class Mutate
    {
        public string Name { get; set; } = default!;
        public string Price { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}