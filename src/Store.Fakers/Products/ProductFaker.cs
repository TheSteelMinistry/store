using System;

using Store.Domain.Products;
using Store.Fakers.Common;

namespace Store.Fakers.Products;

public sealed class ProductFaker : EntityFaker<Product>
{
    public ProductFaker(string locale = "en") : base(locale)
    {
        CustomInstantiator(p => new Product(
            p.Commerce.ProductName(),
            decimal.Parse(p.Commerce.Price()),
            p.Image.PicsumUrl()
        ));
    }
}
