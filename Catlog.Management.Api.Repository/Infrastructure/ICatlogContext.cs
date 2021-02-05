using Catlog.Management.Api.Repository.Entities;
using MongoDB.Driver;
namespace Catlog.Management.Api.Repository.Infrastructure
{
    public interface ICatlogContext
    {
        IMongoCollection<ProductEntities> Products { get; }

    }
}