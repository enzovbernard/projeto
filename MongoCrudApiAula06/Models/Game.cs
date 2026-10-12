using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoCrudApiAula06.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public int ReleaseYear { get; set; }
    }

    public class GameStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string GamesCollectionName { get; set; } = null!;
    }
}

//Database > Collection > Document > Fields