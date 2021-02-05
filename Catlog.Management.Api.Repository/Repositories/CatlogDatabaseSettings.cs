using Catlog.Management.Api.Repository.Infrastructure;
namespace Catlog.Management.Api.Repository.Repositories
{
    public class CatlogDatabaseSettings : ICatlogDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }

    }
}