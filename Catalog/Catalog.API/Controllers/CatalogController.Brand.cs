using System.Net;
using Catalog.API.Controllers.Abstracts;
using Catalog.Application.Commands;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Brand;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public partial class CatalogController:ICatalogControllerBrand
{
 
    [HttpGet]
    [Route("[action]", Name = "GetBrand")]
    [ProducesResponseType(typeof(ProductBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductBrandResponse>> GetBrand(GetBrandQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpGet]
    [Route("[action]", Name = "GetBrands")]
    [ProducesResponseType(typeof(ProductBrand), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductBrandResponse>>> GetBrands(GetBrandsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpDelete]
    [Route("[action]", Name = "RemoveBrand")]
    [ProducesResponseType(typeof(ProductBrand), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveBrand(RemoveBrandCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    [Route("[action]", Name = "RemoveBrands")]
    [ProducesResponseType(typeof(ProductBrand), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveBrands(RemoveBrandsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    [Route("[action]", Name = "UpdateBrand")]
    [ProducesResponseType(typeof(ProductBrand), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}