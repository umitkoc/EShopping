using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories;

public interface IProductRepo
{
    Task<Product> GetProduct(string id);
    Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    Task<Product> CreateProduct(Product product);
    Task<bool> RemoveProduct(string id);
    Task<bool> UpdateProduct(Product product);

    Task<bool> RemoveProducts();
}