using System.Reflection;
using Catalog.Application.Handlers;
using Catalog.Core.Repositories;
using Catalog.Infraestructure.Data;
using Catalog.Infraestructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Catalog.API;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiVersioning();
        services.AddHealthChecks()
            .AddMongoDb(Configuration["DatabaseSettings:ConnectionString"], "Catalog Mongo Db Health Check",
                HealthStatus.Degraded);
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Catalog.API",
                Version = "v1"
            });
        });
        
        // Dependency Injections:
        
        services.AddAutoMapper(typeof(Startup));
        //services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));
        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, ProductRepository>();
        services.AddScoped<ITypesRepository, ProductRepository>();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API - v1"));
        }

        applicationBuilder.UseRouting();
        applicationBuilder.UseStaticFiles();
        applicationBuilder.UseAuthorization();
        applicationBuilder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _=> true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }
    
}