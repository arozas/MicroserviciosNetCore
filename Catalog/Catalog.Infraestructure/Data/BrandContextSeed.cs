using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infraestructure.Data;

public class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
    {
        bool checksBrands = brandCollection.Find(b => true).Any();
        string path = Path.Combine("Data", "SeedData", "brands.json");
        if (!checksBrands)
        {
            var brandData = File.ReadAllText(path);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
            if (brands != null)
            {
                foreach (var item in brands)
                {
                    brandCollection.InsertOneAsync(item);
                }
            }
        }
    }
}