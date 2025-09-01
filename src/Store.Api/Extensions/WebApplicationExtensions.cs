using System;
using Carter;

namespace Store.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddApplicationMiddleware(this WebApplication app)
    {
        app.UseSwaggerMiddleware();
        app.MapCarter();

        return app;
    }

    public static void UseSwaggerMiddleware(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
