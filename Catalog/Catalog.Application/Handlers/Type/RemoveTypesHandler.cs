using Catalog.Application.Commands;
using Catalog.Application.Commands.Type;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Type;

public class RemoveTypesHandler:IRequestHandler<RemoveTypesCommand,bool>
{
    private readonly IProductTypeRepo _repo;
    public RemoveTypesHandler(IProductTypeRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(RemoveTypesCommand request, CancellationToken cancellationToken)
    {
        var typeEntity = await _repo.RemoveTypes();
        var response = Mapper.ProductMapper.Map<bool>(typeEntity);
        return response;
    }
}