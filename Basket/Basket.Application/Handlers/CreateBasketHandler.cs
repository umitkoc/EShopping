using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateBasketHandler:IRequestHandler<CreateBasketCommand,ShoppingCardResponse>
{
    private readonly IBasketRepository _repo;
    public CreateBasketHandler(IBasketRepository repo)
    {
        _repo = repo;
    }
    public async Task<ShoppingCardResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.CreateBasket(new ShoppingCard()
        {
            Username = request.Username,
            ShoppingCardItems = request.ShoppingCardItems
            
        });
        var response = Mapper.CardMapper.Map<ShoppingCardResponse>(entity);
        return response;
    }
}