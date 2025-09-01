using System;
using MudBlazor.Services;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using Store.Client.Web.Clients;
using Store.Client.Web.Options;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Store.Client.Web.Middleware;
using Store.Client.Web.Metrics;

namespace Store.Client.Web.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBlazorServices();
        services.AddMudServices();
        services.AddHttpServices(configuration);
        services.AddOpenTelemetryServices(configuration);
        return services;
    }

    public static void AddBlazorServices(this IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
    }

    public static void AddHttpServices(this IServiceCollection services, IConfiguration configuration)
    {
        ApiOptions productApiOptions = new ProductApiOptions();
        configuration.GetSection(productApiOptions.Section).Bind(productApiOptions);

        services.AddHttpClient<IProductApiClient, ProductApiClient>(client =>
        {
            client.BaseAddress = new Uri(productApiOptions.BaseUrl);
        });
    }

    public static void AddOpenTelemetryServices(this IServiceCollection services, IConfiguration configuration)
    {
        OpenTelemetryOptions openTelemetryOptions = new OpenTelemetryOptions();
        configuration.GetSection(OpenTelemetryOptions.Section).Bind(openTelemetryOptions);

        services.AddOpenTelemetry()
            .ConfigureResource(resource =>
                resource.AddService("Store.Web")
            )
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation();
                metrics.AddHttpClientInstrumentation();
                metrics.AddMeter(UserMetrics.MeterName);
                metrics.AddOtlpExporter(exporter =>
                {
                    exporter.Endpoint = new Uri(openTelemetryOptions.Endpoint);
                });
            })
            .WithLogging(logs =>
            {
                logs.AddOtlpExporter(exporter =>
                {
                    exporter.Endpoint = new Uri(openTelemetryOptions.Endpoint);
                });
            })
            .WithTracing();

    }
}
