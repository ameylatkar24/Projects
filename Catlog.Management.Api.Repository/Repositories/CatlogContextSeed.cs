using MongoDB.Driver;
using System.Collections.Generic;
using Catlog.Management.Api.Repository.Entities;
namespace Catlog.Management.Api.Repository.Repositories
{
    public class CatlogContextSeed
    {
        public static void SeedData(IMongoCollection<ProductEntities> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());

            }
        }
        private static IEnumerable<ProductEntities> GetPreconfiguredProducts()
        {
            return new List<ProductEntities>()
            {
                new ProductEntities()
                {
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                }

            };
        }


    }
}