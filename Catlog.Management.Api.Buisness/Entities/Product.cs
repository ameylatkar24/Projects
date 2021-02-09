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
        public string name { get; set; }
        public string category { get; set; }

        public string summary { get; set; }

        public string description { get; set; }

        public string imageFile { get; set; }

        public decimal price { get; set; }

    }
}