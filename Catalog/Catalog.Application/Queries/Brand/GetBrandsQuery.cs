using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Brand;

public class GetBrandsQuery:IRequest<IEnumerable<ProductBrandResponse>>
{
    
}