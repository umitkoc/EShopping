using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Type;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Type;

public class GetTypeHandler:IRequestHandler<GetTypeQuery,ProductTypeResponse>
{
    private readonly IProductTypeRepo _repo;
    public GetTypeHandler(IProductTypeRepo repo)
    {
        _repo = repo;
    }
    public async Task<ProductTypeResponse> Handle(GetTypeQuery request, CancellationToken cancellationToken)
    {
        var typeEntity = await _repo.GetType(request.Id!);
        var response = Mapper.ProductMapper.Map<ProductTypeResponse>(typeEntity);
        return response;
    }
}