using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands.Product;

public  class UpdateProductCommand:IRequest<bool>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    [BsonElement("Name")]
    public string? Name { get; init; }
    public string? Summary { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public decimal Price { get; init; }
    public ProductBrand? ProductBrands { get; init; }
    public ProductType? ProductType { get; init; }
   
}