using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Product;
using Catalog.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.Abstracts;

public interface ICatalogControllerProduct
{
    public  Task<ActionResult<ProductResponse>> GetProduct([FromBody] GetProductQuery query);
    public Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts([FromQuery] GetProductsQuery query);
    public  Task<ActionResult> RemoveProduct([FromBody] RemoveProductCommand command);
    public Task<ActionResult> RemoveProducts([FromBody] RemoveProductsCommand command);
    public  Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command);
}