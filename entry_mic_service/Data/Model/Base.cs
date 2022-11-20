using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace entry_mic_service.Data.Model
{
    public class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
