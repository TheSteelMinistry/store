using System;
using Microsoft.Extensions.DependencyInjection;
using Store.Services.Products;

namespace Store.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();

        return services;
    }
}
