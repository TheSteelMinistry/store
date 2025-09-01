using Carter;
using Carter.Request;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products;
using Store.Shared.Products;

namespace Store.Api.Products;

public sealed class GetProductIndex : ICarterModule
{
    public async Task<IResult> Handle(HttpRequest request, [FromServices] IProductService productService)
    {
        ProductRequest.Index productRequest = request.Query.As<ProductRequest.Index>("product");

        ProductResponse.Index response = await productService.GetProductsAsync(productRequest);

        return Results.Ok(response);
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/product", Handle)
            .WithName("GetProducts")
            .WithOpenApi();
    }
}
