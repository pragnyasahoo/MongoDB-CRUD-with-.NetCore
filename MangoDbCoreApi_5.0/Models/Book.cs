using MangoDbCoreApi_5._0.Models.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoDbCoreApi_5._0.Models
{

    public class Book: IBook
    { 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]    
        public string Id { get; set; }

        [BsonElement("name")]
        public string bookName { get; set; }

        [BsonElement("price")]
        public decimal BookPrice { get; set; }

        public string category { get; set; }

        public Author author { get; set; }
    }

}   
