using Catalog.Application.Queries;
using Catalog.Application.Queries.Product;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;
using Mapper = Catalog.Application.Mappers.Mapper;

namespace Catalog.Application.Handlers.Product;

public class GetProductsHandler:IRequestHandler<GetProductsQuery,Pagination<ProductResponse>>
{
    private readonly IProductRepo _product;
    public GetProductsHandler(IProductRepo product)
    {
        _product = product;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _product.GetProducts(request.Params!);
        var productResponseList = Mapper.ProductMapper.Map<Pagination<ProductResponse>>(productList);
        return productResponseList;

    }
}