using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepo:IProductRepo
{
    private readonly IContext _context;

    public ProductRepo(IContext context)
    {
        _context = context;
    }
    public async Task<Product> GetProduct(string id)
    {
        return await _context
            .Products
            .Find(p=>p.Id==id)
            .FirstOrDefaultAsync();
    }

    public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;
        var pagination = new Pagination<Product>();
        if (catalogSpecParams.Search is not null)
        {
            var searchFilter = builder.Regex(r => r.Name, new BsonRegularExpression(catalogSpecParams.Search));
            filter &= searchFilter;
        }
        if (catalogSpecParams.BrandId is not null)
        {
            var brandFilter = builder.Eq(r => r.ProductBrands!.Id, catalogSpecParams.BrandId);
            filter &= brandFilter;
        }
        if (catalogSpecParams.TypeId is not null)
        {
            var typeFilter = builder.Eq(r => r.ProductType!.Id, catalogSpecParams.TypeId);
            filter &= typeFilter;
        }

        if (catalogSpecParams.Sort is not null)
        {
            pagination.Data = await DataFilter(catalogSpecParams, filter);
        }
        else
        {
            pagination.Data = await _context.Products.Find(filter)
                .Skip(catalogSpecParams.Size * (catalogSpecParams.Index - 1)).ToListAsync();
        }


        pagination.Size = catalogSpecParams.Size;
        pagination.Index = catalogSpecParams.Index;
        pagination.Count = await _context.Products.CountDocumentsAsync(c => true);
        pagination.Data = await _context.Products.Find(filter)
            .Sort(Builders<Product>.Sort.Ascending("Name"))
            .Skip(catalogSpecParams.Size*(catalogSpecParams.Index-1))
            .Limit(catalogSpecParams.Size)
            .ToListAsync();
        return pagination;
    }

    private async Task<IReadOnlyList<Product>?> DataFilter(CatalogSpecParams catalogSpecParams, FilterDefinition<Product> filter)
    {
        return  catalogSpecParams.Sort switch
        {
            "priceAsc" => await _context.Products.Find(filter)
                .Sort(Builders<Product>.Sort.Ascending("Price"))
                .Skip(catalogSpecParams.Size * (catalogSpecParams.Index - 1))
                .Limit(catalogSpecParams.Size)
                .ToListAsync(),
            "priceDesc" => await _context.Products.Find(filter)
                .Sort(Builders<Product>.Sort.Descending("Price"))
                .Skip(catalogSpecParams.Size * (catalogSpecParams.Index - 1))
                .Limit(catalogSpecParams.Size)
                .ToListAsync(),
            "NameDesc" => await _context.Products.Find(filter)
                .Sort(Builders<Product>.Sort.Descending("Name"))
                .Skip(catalogSpecParams.Size * (catalogSpecParams.Index - 1))
                .Limit(catalogSpecParams.Size)
                .ToListAsync(),
            _ => await _context.Products.Find(filter)
                .Sort(Builders<Product>.Sort.Ascending("Name"))
                .Skip(catalogSpecParams.Size * (catalogSpecParams.Index - 1))
                .Limit(catalogSpecParams.Size)
                .ToListAsync()
        };

    }

    public async Task<Product> CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> RemoveProduct(string id)
    {

        var filter = Builders<Product>.Filter.Eq(i => i.Id,id);
        var result= await _context.Products.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _context.Products.ReplaceOneAsync(i => i.Id == product.Id, product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> RemoveProducts()
    {
        var result = await _context.Products.DeleteManyAsync(i => true);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<ProductBrand> GetBrand(string id)
    {
        return await _context.Brands.Find(b => b.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ProductType> GetProductType(string id)
    {
        return await _context.Types.Find(b => b.Id == id).FirstOrDefaultAsync();
    }

  
}