using Catlog.Management.Api.Repository.Infrastructure;
using Catlog.Management.Api.Repository.Entities;
using MongoDB.Driver;

namespace Catlog.Management.Api.Repository.Repositories
{
    public class CatlogContext : ICatlogContext
    {
        public CatlogContext(ICatlogDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Products = database.GetCollection<ProductEntities>(settings.CollectionName);
            CatlogContextSeed.SeedData(Products);
        }
        public IMongoCollection<ProductEntities> Products { get; }
    }
}