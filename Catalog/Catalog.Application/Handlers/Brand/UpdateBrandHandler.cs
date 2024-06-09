using Catalog.Application.Commands;
using Catalog.Application.Commands.Brand;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Brand;

public class UpdateBrandHandler:IRequestHandler<UpdateBrandCommand,bool>
{
    private readonly IProductBrandRepo _repo;

    public UpdateBrandHandler(IProductBrandRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brandEntity =await _repo.UpdateBrand(new ProductBrand()
        {
            Id = request.Id,
            Name = request.Name
        });
        var response =  Mapper.ProductMapper.Map<bool>(brandEntity);
        return response;
    }
}