using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.
   AddJsonFile("appsettings.json", optional: false,reloadOnChange:true).
   AddJsonFile("appsettings.Development.json",optional:true,reloadOnChange:true);
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddHealthChecks()
   .AddMongoDb(
      builder.Configuration["DatabaseSettings:ConnectionString"]!,
      "Catalog mongo db HealthCheck",
      HealthStatus.Degraded);
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductBrandRepo, ProductBrandRepo>();
builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
builder.Services.AddScoped<IContext, Context>();

var app = builder.Build();

var environment = app.Environment;
if (environment.IsDevelopment())
{
   app.UseDeveloperExceptionPage();
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.DefaultModelsExpandDepth(-1); // schemas hide
      c.SwaggerEndpoint("/swagger/v1/swagger.json","Catalog.API");
      
   });
}
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
   endpoints.MapControllers();
   endpoints.MapHealthChecks("/health",new HealthCheckOptions()
   {
      Predicate = _ =>true,
      ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
   });
});

app.Run();