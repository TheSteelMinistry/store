using Store.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices();

WebApplication app = builder.Build();

app.AddApplicationMiddleware();

app.Run();
