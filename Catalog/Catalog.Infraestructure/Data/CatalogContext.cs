using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infraestructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; set; }
    public IMongoCollection<ProductBrand> Brands { get; set; }
    public IMongoCollection<ProductType> Types { get; set; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSetting:BrandsCollections"));
        Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSetting:TypesCollections"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSetting:ProductsCollections"));
        
        BrandContextSeed.SeedData(Brands);
        TypeContextSeed.SeedData(Types);
        CatalogContextSeed.SeedData(Products);
    }
}