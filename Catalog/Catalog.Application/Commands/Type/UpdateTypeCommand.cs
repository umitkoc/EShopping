using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands.Type;

public class UpdateTypeCommand:IRequest<bool>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    
    [BsonElement("Name")]
    public string? Name { get; init; }
}