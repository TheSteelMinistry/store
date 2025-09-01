using System;

namespace Store.Shared.Products;

public abstract class ProductRequest
{
    public sealed class Index
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 25;
        public string? Searchterm { get; set; }
    }
}
