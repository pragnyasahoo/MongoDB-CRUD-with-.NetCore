using MangoDbCoreApi_5.Models.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoDbCoreApi_5.Models
{
    public class Users : IUser
    {
        //https://medium.com/nerd-for-tech/net-jwt-authentication-with-mongodb-9bca4a33d3f0
        //https://errorandsolution.com/net-core-jwt-authentication/
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("userId")]
        public string Id { get; set; }

        [BsonElement("userName")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        [BsonRequired]
        public string Password { get; set; }
    }
}
