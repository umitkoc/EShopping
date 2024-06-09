using System.Reflection;
using Discount.Core.Repositories;
using Discount.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddGrpc();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" }); });
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddScoped<IDiscountRepo, DiscountRepo>();


var app = builder.Build();

var environment = app.Environment;
if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1); // schemas hide
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount.API");

    });
}

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();