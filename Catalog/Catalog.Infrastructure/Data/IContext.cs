using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface IContext
{
    public IMongoCollection<Product> Products { get; set; }
    public IMongoCollection<ProductBrand> Brands { get;}
    public IMongoCollection<ProductType> Types { get;}
}