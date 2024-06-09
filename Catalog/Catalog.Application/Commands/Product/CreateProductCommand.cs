using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands.Product;

public  class CreateProductCommand:IRequest<ProductResponse>
{
    public string? Name { get; init; }
    public string? Summary { get; init; }
    public string? Description { get; init; }
    public ProductBrand? ProductBrands { get; init; }
    public ProductType? ProductType { get; init; }
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }
}