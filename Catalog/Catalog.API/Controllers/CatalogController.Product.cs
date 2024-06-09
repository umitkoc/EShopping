using System.Net;
using Catalog.API.Controllers.Abstracts;
using Catalog.Application.Commands;
using Catalog.Application.Commands.Product;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Product;
using Catalog.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public partial class CatalogController:ICatalogControllerProduct
{
    [HttpGet]
    [Route("[action]",Name = "GetProduct")]
    [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProduct([FromBody] GetProductQuery query)
    {
        var result =await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]")]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts([FromQuery]GetProductsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("[action]",Name = "RemoveProduct")]
    [ProducesResponseType(typeof(bool),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool),(int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> RemoveProduct([FromBody]RemoveProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    [Route("[action]", Name = "RemoveProducts")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveProducts([FromBody] RemoveProductsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPut]
    [Route("[action]",Name = "UpdateProduct")]
    [ProducesResponseType(typeof(bool),(int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateProduct([FromBody]UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}