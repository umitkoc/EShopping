using Catalog.Application.Commands;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Brand;
using Catalog.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.Abstracts;

public interface ICatalogControllerBrand
{
    public  Task<ActionResult<ProductBrandResponse>> GetBrand([FromBody] GetBrandQuery query);
    public Task<ActionResult<IEnumerable<ProductBrandResponse>>> GetBrands([FromQuery] GetBrandsQuery query);
    public  Task<ActionResult> RemoveBrand([FromBody] RemoveBrandCommand command);
    public Task<ActionResult> RemoveBrands([FromBody] RemoveBrandsCommand command);
    public  Task<ActionResult> UpdateBrand([FromBody] UpdateBrandCommand command);
}