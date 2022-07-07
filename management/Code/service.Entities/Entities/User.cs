using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace service.Entities.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string username  { get; set; }
        public int id  { get; set; }
        
    }

}
