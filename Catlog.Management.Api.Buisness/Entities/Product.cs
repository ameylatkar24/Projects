using System;
using System.Collections.Generic;
using Catlog.Management.Api.Repository.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace Catlog.Management.Api.Buisness.Entities
{

    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string id { get; set; }
        //[BsonRepresentation(BsonType.String)]
        public string name { get; set; }
        // [BsonRepresentation(BsonType.String)]

        public string category { get; set; }
        // [BsonRepresentation(BsonType.String)]

        public string summary { get; set; }
        //[BsonRepresentation(BsonType.String)]

        public string description { get; set; }
        //[BsonRepresentation(BsonType.String)]

        public string imageFile { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]

        public decimal price { get; set; }

    }
}