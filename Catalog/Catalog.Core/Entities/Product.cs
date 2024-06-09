using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product:BaseEntity
{

    public string? Summary { get; set; }
    public string? Description { get; set; }
    public ProductBrand? ProductBrands { get; set; }
    public ProductType? ProductType { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    
    
  
}