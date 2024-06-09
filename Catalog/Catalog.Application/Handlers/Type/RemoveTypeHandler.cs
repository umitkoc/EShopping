using Catalog.Application.Commands;
using Catalog.Application.Commands.Type;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Type;

public class RemoveTypeHandler:IRequestHandler<RemoveTypeCommand,bool>
{
    private readonly IProductTypeRepo _repo;
    public RemoveTypeHandler(IProductTypeRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(RemoveTypeCommand request, CancellationToken cancellationToken)
    {
        var typeEntity = await _repo.RemoveType(request.Id!);
        var response = Mapper.ProductMapper.Map<bool>(typeEntity);
        return response;
    }
}