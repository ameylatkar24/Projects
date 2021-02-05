using System.Collections.Generic;
using System.Threading.Tasks;
using Catlog.Management.Api.Repository.Entities;
namespace Catlog.Management.Api.Repository.Infrastructure
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntities>> GetProducts();

        Task<ProductEntities> GetProductById(string id);

        Task<IEnumerable<ProductEntities>> GetProductByName(string name);

        Task<IEnumerable<ProductEntities>> GetProductByCategory(string category);

        Task Create(ProductEntities product);

        Task<bool> Update(ProductEntities product);

        Task<bool> Delete(string id);

    }
}