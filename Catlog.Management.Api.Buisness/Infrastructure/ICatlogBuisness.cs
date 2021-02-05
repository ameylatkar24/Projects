using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using System.Net;

using Catlog.Management.Api.Repository.Infrastructure;
using Catlog.Management.Api.Repository.Repositories;
using Catlog.Management.Api.Repository.Entities;

namespace Catlog.Management.Api.Buisness.Infrastructure
{
    public interface ICatlogBuisness
    {
        Task<IEnumerable<ProductEntities>> GetProducts();
        Task<ProductEntities> GetProductByid(string id);
        Task<ProductEntities> CreateProduct(ProductEntities product);
        Task<bool> DeleteProductByid(string id);
        Task<bool> Updateproduct(ProductEntities value);
        Task<IEnumerable<ProductEntities>> GetProductBycategory(string category);

    }
}