using MangoDbCoreApi_5.Models.Abstract;
using MangoDbCoreApi_5.Models.ContentDbModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MangoDbCoreApi_5.Models
{

    [BsonCollection("Bookstore")]
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

        public DateTime CreatedAt => System.DateTime.Now;
    }

}   
