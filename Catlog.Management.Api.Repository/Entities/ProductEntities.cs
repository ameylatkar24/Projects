
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Catlog.Management.Api.Repository.Entities
{
    public class ProductEntities
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public string Price { get; set; }

    }
}