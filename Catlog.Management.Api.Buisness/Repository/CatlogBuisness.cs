using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using System.Net;

using Catlog.Management.Api.Buisness.Infrastructure;
using Catlog.Management.Api.Repository.Infrastructure;
using Catlog.Management.Api.Repository.Entities;
namespace Catlog.Management.Api.Buisness.Repository
{
    public class CatlogBuisness : ICatlogBuisness
    {
        private readonly IProductRepository _repository;
        public CatlogBuisness(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductEntities>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return products;

        }
        public async Task<ProductEntities> GetProductByid(string id)
        {
            var product = await _repository.GetProductById(id);
            return (product);
        }


        public async Task<ProductEntities> CreateProduct(ProductEntities product)
        {
            await _repository.Create(product);
            return (product);
        }



        public async Task<bool> DeleteProductByid(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> Updateproduct(ProductEntities value)
        {
            return (await _repository.Update(value));
        }

        public async Task<IEnumerable<ProductEntities>> GetProductBycategory(string category)
        {
            return (await _repository.GetProductByCategory(category));

        }

    }
}