using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

public class UpdateBasketCommand:IRequest<ShoppingCardResponse>
{
    public string? Username { get; set; }
    public IEnumerable<ShoppingCardItem>? ShoppingCardItems { get; set; }
}