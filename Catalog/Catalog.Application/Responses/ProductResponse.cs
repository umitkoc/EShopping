using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Responses;

public class ProductResponse : BaseResponse
{
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public ProductBrand? ProductBrands { get; set; }
    public ProductType? ProductType { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}