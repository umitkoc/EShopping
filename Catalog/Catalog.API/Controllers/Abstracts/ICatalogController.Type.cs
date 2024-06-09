using Catalog.Application.Commands;
using Catalog.Application.Commands.Type;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Type;
using Catalog.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.Abstracts;

public interface ICatalogControllerType
{
    public  Task<ActionResult<ProductTypeResponse>> GetType([FromBody] GetTypeQuery query);
    public Task<ActionResult<IEnumerable<ProductTypeResponse>>> GetTypes([FromQuery] GetTypesQuery query);
    public  Task<ActionResult> RemoveType([FromBody] RemoveTypeCommand command);
    public Task<ActionResult> RemoveTypes([FromBody] RemoveTypesCommand command);
    public  Task<ActionResult> UpdateType([FromBody] UpdateTypeCommand command);
}