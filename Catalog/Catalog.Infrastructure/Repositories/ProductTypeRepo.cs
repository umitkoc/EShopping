using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductTypeRepo:IProductTypeRepo
{

    private readonly IContext _context;
    public ProductTypeRepo(IContext context)
    {
        _context = context;
    }
    
    public async Task<ProductType> GetType(string id)
    {
        return await _context.Types.Find(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProductType>> GetTypes()
    {
        return await _context.Types.Find(i => true).ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetTypes(string id)
    {
        return await _context.Types.Find(i => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByType(string id)
    {
        return await _context.Products.Find(i=>i.ProductType!.Id==id).ToListAsync();
        
    }

    public async Task<bool> RemoveType(string id)
    {
        var filter = Builders<ProductType>.Filter.Eq(i => i.Id, id);
        var result = await _context.Types.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public Task<bool> RemoveTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateType(ProductType productType)
    {
        var result = await _context.Types.ReplaceOneAsync(i => i.Id == productType.Id, productType);
        return result.IsAcknowledged && result.IsModifiedCountAvailable;
    }

    public async Task<ProductType> CreateType(ProductType productType)
    {
        await _context.Types.InsertOneAsync(productType);
        return productType;
    }
}