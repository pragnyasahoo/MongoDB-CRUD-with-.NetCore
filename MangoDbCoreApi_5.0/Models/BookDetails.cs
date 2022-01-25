using MongoDB.Bson.Serialization.Attributes;

namespace MangoDbCoreApi_5._0.Models
{
    public class BookDetails
    {
    }
    public class BookResponse
    { 
        [BsonElement("id")] 
        public string BookId { get; set; }
    }
}
