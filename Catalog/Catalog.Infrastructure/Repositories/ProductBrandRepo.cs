using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductBrandRepo : IProductBrandRepo
{
    private readonly IContext _context;
    public ProductBrandRepo(IContext context)
    {
        _context = context;
    }
    public async Task<ProductBrand> GetBrand(string id)
    {
        return await _context.Brands.Find(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProductBrand>> GetBrands()
    {
        return await _context.Brands.Find(i => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByBrand(string id)
    {
        return await _context.Products.Find(i => i.ProductBrands!.Id==id).ToListAsync();
    }

    public async Task<bool> RemoveBrand(string? id)
    {
        var filter = Builders<ProductBrand>.Filter.Eq(i => i.Id, id);
        var result = await _context.Brands.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> RemoveBrands()
    {
        var result = await _context.Brands.DeleteManyAsync(i => true);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> UpdateBrand(ProductBrand brand)
    {
        var result = await _context.Brands.ReplaceOneAsync(i=>i.Id==brand.Id,brand);
        return result.IsAcknowledged && result.IsModifiedCountAvailable;
    }

    public async Task<ProductBrand> CreateBrand(ProductBrand brand)
    {
         await _context.Brands.InsertOneAsync(brand);
         return brand;
    }
}