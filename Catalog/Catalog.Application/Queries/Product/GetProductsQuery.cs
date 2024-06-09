using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries.Product;

public  class GetProductsQuery:IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams? Params { get; set; }
}