using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using System.Net;

using Catlog.Management.Api.Buisness.Infrastructure;
using Catlog.Management.Api.Repository.Entities;
using Catlog.Management.Api.Buisness.Entities;
using Catlog.Management.Api.Repository.Infrastructure;
using AutoMapper;
using Catlog.Management.Api.Buisness.Mapper;
namespace Catlog.Management.Api.Buisness.Repository
{
    public class CatlogBuisness : ICatlogBuisness
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CatlogBuisness(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductEntities>> GetProducts()
        {
            Product prod = new Product();
            var prodEntity = _mapper.Map<ProductEntities>(prod);
            return await _repository.GetProducts();
        }

        public async Task<ProductEntities> CreateProduct(Product product)
        {
            var prodent = _mapper.Map<ProductEntities>(product);
            await _repository.Create(prodent);
            return prodent;



        }
        public async Task<ProductEntities> GetProductByid(string id)
        {
            Product prod = new Product();
            var prodEntity = _mapper.Map<ProductEntities>(prod);
            var product = await _repository.GetProductById(id);
            return (product);
        }

        public async Task<IEnumerable<ProductEntities>> GetProductBycategory(string category)
        {
            Product prod = new Product();
            var prodEntity = _mapper.Map<ProductEntities>(prod);

            return (await _repository.GetProductByCategory(category));

        }
        public async Task<bool> DeleteProductByid(string id)
        {
            Product prod = new Product();
            var prodEntity = _mapper.Map<ProductEntities>(prod);

            return await _repository.Delete(id);
        }

        public async Task<bool> Updateproduct(Product value)
        {
            var prodent = _mapper.Map<ProductEntities>(value);
            return (await _repository.Update(prodent));
        }
        public int countItems()
        {
            ProductEntities p = new ProductEntities();

            List<string> counting = new List<string>();

            counting.Add(p.Name);
            Console.WriteLine(counting.Count());
            return counting.Count();
        }

        public long Counting()
        {
            return _repository.TotalCount();
        }

        /*








*/

    }
}