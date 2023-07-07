using Catalog.Service.EventHandlers;
using Catalog.Service.Queries;
using Catalog.Service.Queries.Interfaces;
using CatalogPersistanceDatabase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogApi"));
            });

            // Adding autoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Adding QueryService
            builder.Services.AddTransient<IProductQueryService, ProductQueryService>();

            // Adding Mediator
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ProductCreateEventHandler).Assembly));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}