using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductTypeRepo
{
    Task<ProductType> GetType(string id);
    Task<IEnumerable<ProductType>> GetTypes();
    Task<IEnumerable<Product>> GetProductsByType(string id);
    Task<bool> RemoveType(string id);
    Task<bool> RemoveTypes();
    Task<bool> UpdateType(ProductType productType);
    Task<ProductType> CreateType(ProductType productType);
}