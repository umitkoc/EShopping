using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Brand;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Brand;

public class GetBrandHandler:IRequestHandler<GetBrandQuery,ProductBrandResponse>
{
    private readonly IProductBrandRepo _repo;
    public GetBrandHandler(IProductBrandRepo repo)
    {
        _repo = repo;
    }
    public async Task<ProductBrandResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var brandEntity =await _repo.GetBrand(request.Id!);
        var response =  Mapper.ProductMapper.Map<ProductBrandResponse>(brandEntity);
        return response;
    }
}