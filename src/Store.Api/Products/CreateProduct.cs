using System;
using Carter;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products;
using Store.Shared.Products;

namespace Store.Api.Products;

public sealed class CreateProduct : ICarterModule
{
    public async Task<IResult> Handle(HttpContext ctx, [FromServices] IProductService productService)
    {
        ProductResponse.Create response = await productService.CreateProductAsync();

        return Results.Created($"/api/product/{response.Id}", response);
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/product", Handle)
            .WithName("CreateProduct")
            .WithOpenApi();
    }
}
