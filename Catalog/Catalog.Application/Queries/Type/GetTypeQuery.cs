using Catalog.Application.Responses;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Queries.Type;

public class GetTypeQuery:IRequest<ProductTypeResponse>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}