using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Queries.Product;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Product;

public class GetProductHandler:IRequestHandler<GetProductQuery,ProductResponse>
{
    private readonly IProductRepo _repo;
    public GetProductHandler(IProductRepo repo)
    {
        _repo = repo;
    }
    
    
    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetProduct(request.Id!);
        var productResponse = Mapper.ProductMapper.Map<ProductResponse>(product);
        return productResponse;
    }
}