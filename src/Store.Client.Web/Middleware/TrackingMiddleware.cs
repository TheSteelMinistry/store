using System;
using Store.Client.Web.Metrics;

namespace Store.Client.Web.Middleware;

public class TrackingMiddleware
{
    private readonly RequestDelegate _next;

    public TrackingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Guid userId = Guid.NewGuid();

        UserMetrics.PingRequest(userId.ToString());

        try
        {
            await _next(context);
        }
        finally
        {

        }
    }
}
