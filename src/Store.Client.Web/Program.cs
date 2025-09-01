using Store.Client.Web.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration);

WebApplication app = builder.Build();

app.AddApplicationMiddleware();

app.Run();
