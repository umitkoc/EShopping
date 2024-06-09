using Catalog.Application.Commands.Type;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Type;

public class UpdateTypeHandler:IRequestHandler<UpdateTypeCommand,bool>
{
    private readonly IProductTypeRepo _repo;
    public UpdateTypeHandler(IProductTypeRepo repo)
    {
        _repo = repo;
    }
    
    public async Task<bool> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
    {
        var typeEntity = await _repo.UpdateType(new ProductType()
        {
            Id = request.Id,
            Name = request.Name
        });
        var response = Mapper.ProductMapper.Map<bool>(typeEntity);
        return response;
    }
}