using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Brand;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Brand;

public class GetBrandsHandler:IRequestHandler<GetBrandsQuery,IEnumerable<ProductBrandResponse>>
{
    private readonly IProductBrandRepo _repo;

    public GetBrandsHandler(IProductBrandRepo repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<ProductBrandResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var brandEntity =await _repo.GetBrands();
        var response =  Mapper.ProductMapper.Map<IList<ProductBrandResponse>>(brandEntity);
        return response;
    }
}