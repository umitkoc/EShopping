using System.Text.Json;
using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class Context:IContext
{
    public IMongoCollection<Product> Products { get; set; }
    public IMongoCollection<ProductBrand> Brands { get; }
    public IMongoCollection<ProductType> Types { get; }

    public Context(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductsName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsName"));
        Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesName"));
        
        SeedData(Products,"products");
        SeedData(Brands,"brands");
        SeedData(Types,"types");
        
    }
    
    private static async void SeedData<T>(IMongoCollection<T> collection,string name)
    {
        var check = await collection.Find(b => true).AnyAsync();
        if (check) return;
        var data = await File.ReadAllTextAsync($"../Catalog.Infrastructure/Data/SeedData/{name}.json");
        var model = JsonSerializer.Deserialize<List<T>>(data);
        if (model is not null)
            await collection.InsertManyAsync(model);
    }
}