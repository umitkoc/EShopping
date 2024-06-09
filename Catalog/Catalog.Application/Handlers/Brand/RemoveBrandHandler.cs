using Catalog.Application.Commands;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Brand;

public class RemoveBrandHandler:IRequestHandler<RemoveBrandCommand,bool>
{
    private readonly IProductBrandRepo _repo;

    public RemoveBrandHandler(IProductBrandRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
    {
        var brandEntity =await _repo.RemoveBrand(request.Id!);
        var response =  Mapper.ProductMapper.Map<bool>(brandEntity);
        return response;
    }
}