using System.Collections;
using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductBrandRepo
{
    Task<ProductBrand> GetBrand(string id);
    Task<IEnumerable<ProductBrand>> GetBrands();
    Task<IEnumerable<Product>> GetProductsByBrand(string id);
    Task<bool> RemoveBrand(string id);
    Task<bool> RemoveBrands();
    Task<bool> UpdateBrand(ProductBrand brand);
    Task<ProductBrand> CreateBrand(ProductBrand brand);
}