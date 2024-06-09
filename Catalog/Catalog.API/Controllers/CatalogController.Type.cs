using System.Net;
using Catalog.API.Controllers.Abstracts;
using Catalog.Application.Commands;
using Catalog.Application.Commands.Type;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Type;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public partial class CatalogController:ICatalogControllerType
{
    [HttpGet]
    [Route("[action]", Name = "GetType")]
    [ProducesResponseType(typeof(ProductType), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductTypeResponse>> GetType(GetTypeQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]", Name = "GetTypes")]
    [ProducesResponseType(typeof(ProductType), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductTypeResponse>>> GetTypes(GetTypesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete]
    [Route("[action]", Name = "RemoveType")]
    [ProducesResponseType(typeof(ProductType), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveType(RemoveTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("[action]", Name = "RemoveTypes")]
    [ProducesResponseType(typeof(ProductType), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveTypes(RemoveTypesCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Route("[action]", Name = "UpdateType")]
    [ProducesResponseType(typeof(ProductType), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateType(UpdateTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}