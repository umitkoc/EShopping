using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public partial class BasketController
{
     
     
     [HttpGet]
     [Route("[action]",Name = "GetBasket")]
     [ProducesResponseType(typeof(ShoppingCardResponse),(int)HttpStatusCode.OK)]
     public async Task<ActionResult<ShoppingCardResponse>> GetBasket([FromBody] GetBasketQuery query)
     {
          var result = await _mediator.Send(query);
          return Ok(result);
     }

     [HttpDelete]
     [Route("[action]", Name = "RemoveBasket")]
     [ProducesResponseType(typeof(ShoppingCardResponse), (int)HttpStatusCode.OK)]
     public async Task<ActionResult> GetBasket([FromBody] RemoveBasketCommand command)
     {
          var result = await _mediator.Send(command);
          return Ok(result);
     }

     [HttpPost]
     [Route("[action]", Name = "CreateBasket")]
     [ProducesResponseType(typeof(ShoppingCardResponse), (int)HttpStatusCode.OK)]
     public async Task<ActionResult> CreateBasket([FromBody] CreateBasketCommand command)
     {
          var result = await _mediator.Send(command);
          return Ok(result);
     }

     [HttpPut]
     [Route("[action]", Name = "UpdateBasket")]
     [ProducesResponseType(typeof(ShoppingCardResponse), (int)HttpStatusCode.OK)]
     public async Task<ActionResult> UpdateBasket([FromBody] UpdateBasketCommand command)
     {
          var result = await _mediator.Send(command);
          return Ok(result);
     }
}