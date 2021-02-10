using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using Catlog.Management.Api.Repository.Infrastructure;
using Catlog.Management.Api.Repository.Entities;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace Catlog.Management.Api.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatlogContext _catlogContext;
        public ProductRepository(ICatlogContext catlogContext)
        {
            _catlogContext = catlogContext;

        }
        public async Task<IEnumerable<ProductEntities>> GetProducts()
        {
            return await _catlogContext.Products.Find(p => true).ToListAsync();
        }
        public async Task<ProductEntities> GetProductById(string id)
        {
            return await _catlogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ProductEntities>> GetProductByName(string name)
        {
            FilterDefinition<ProductEntities> filter = Builders<ProductEntities>.Filter.ElemMatch(p => p.Name, name);
            return await _catlogContext
                         .Products
                         .Find(filter)
                         .ToListAsync();
        }
        public async Task<IEnumerable<ProductEntities>> GetProductByCategory(string category)
        {
            FilterDefinition<ProductEntities> filter = Builders<ProductEntities>.Filter.ElemMatch(p => p.Category, category);

            return await _catlogContext
                         .Products
                         .Find(filter)
                         .ToListAsync();


        }





        public async Task Create(ProductEntities product)
        {
            await _catlogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(ProductEntities product)
        {
            var updateResult = await _catlogContext
                            .Products
                            .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;

        }


        public async Task<bool> Delete(string id)
        {
            FilterDefinition<ProductEntities> filter = Builders<ProductEntities>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _catlogContext
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public long TotalCount()
        {
            //var query = _catlogContext.Products.Find(p => true);
            return _catlogContext.Products.CountDocuments(p => true);
        }
    }
}