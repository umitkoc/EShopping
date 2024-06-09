using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Type;

public class GetTypesQuery:IRequest<IEnumerable<ProductTypeResponse>>
{
    
}