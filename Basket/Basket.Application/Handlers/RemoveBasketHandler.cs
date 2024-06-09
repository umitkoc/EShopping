using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class RemoveBasketHandler:IRequestHandler<RemoveBasketCommand>
{
    private readonly IBasketRepository _repo;
    public RemoveBasketHandler(IBasketRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
    {
        await _repo.RemoveBasket(request.Username!);
        return Unit.Value;
    }
}