using MangoDbCoreApi_5.Models.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoDbCoreApi_5.Models
{
    public class Author : IAuthor
    {
        
        [BsonElement("firstname")]
        [BsonRequired]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public  string LastName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonRequired]
        public string Location { get; set; }
    }
}
