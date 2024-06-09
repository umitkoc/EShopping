using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Type;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Type;

public class GetTypesHandler:IRequestHandler<GetTypesQuery,IEnumerable<ProductTypeResponse>>
{
    private readonly IProductTypeRepo _repo;
    public GetTypesHandler(IProductTypeRepo repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<ProductTypeResponse>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
    {
        var typeEntity = await _repo.GetTypes();
        var response = Mapper.ProductMapper.Map<IEnumerable<ProductTypeResponse>>(typeEntity);
        return response;
    }
}