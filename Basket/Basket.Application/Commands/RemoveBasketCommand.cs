using MediatR;

namespace Basket.Application.Commands;

public class RemoveBasketCommand:IRequest
{
    public string? Username { get; set; }
}