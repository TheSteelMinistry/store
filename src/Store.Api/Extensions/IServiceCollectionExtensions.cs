using System;
using Carter;
using Store.Services;

namespace Store.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSwaggerServices();
        services.AddCarter();
        services.AddRestServices();

        return services;
    }

    private static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
