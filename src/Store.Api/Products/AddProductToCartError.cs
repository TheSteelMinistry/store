using Carter;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products;

namespace Store.Api.Products;

public class AddProductToCartError : ICarterModule
{
    public IResult Handle([FromServices] ILogger<AddProductToCartError> logger)
    {
        logger.LogError("There was an error adding the product to the cart.");
        return Results.Problem("There was an error adding the product to the cart.");
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/product/cart/error", Handle)
            .WithName("AddProductToCartError")
            .WithOpenApi();
    }
}
