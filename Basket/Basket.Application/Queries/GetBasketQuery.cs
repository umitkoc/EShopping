using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketQuery:IRequest<ShoppingCardResponse>
{
    public string? Username { get; set; }
}