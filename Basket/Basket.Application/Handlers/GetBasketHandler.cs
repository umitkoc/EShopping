using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketHandler:IRequestHandler<GetBasketQuery,ShoppingCardResponse>
{
    private readonly IBasketRepository _repo;
    public GetBasketHandler(IBasketRepository repo)
    {
        _repo = repo;
    }
    public async Task<ShoppingCardResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetBasket(request.Username!);
        var response = Mapper.CardMapper.Map<ShoppingCardResponse>(entity);
        return response;
    }
}