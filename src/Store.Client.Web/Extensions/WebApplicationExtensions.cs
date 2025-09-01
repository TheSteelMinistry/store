using System;
using Store.Client.Web.Middleware;

namespace Store.Client.Web.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddApplicationMiddleware(this WebApplication app)
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.UseMiddleware<TrackingMiddleware>();

        return app;
    }
}
