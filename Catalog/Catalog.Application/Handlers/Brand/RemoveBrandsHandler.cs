using Catalog.Application.Commands;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Brand;

public class RemoveBrandsHandler:IRequestHandler<RemoveBrandsCommand,bool>
{
    private readonly IProductBrandRepo _repo;

    public RemoveBrandsHandler(IProductBrandRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(RemoveBrandsCommand request, CancellationToken cancellationToken)
    {
        var brandEntity =await _repo.RemoveBrands();
        var response =  Mapper.ProductMapper.Map<bool>(brandEntity);
        return response;
    }
}