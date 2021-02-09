using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catlog.Management.Api.Buisness.Repository;
//using Catlog.Management.Api.Repository.Entities;
using Catlog.Management.Api.Buisness.Infrastructure;
//using Catlog.Management.Api.Buisness.Mapper;
using Catlog.Management.Api.Buisness.Entities;
using AutoMapper;

namespace Catlog.Management.Api.Controllers
{
    [Route("api/v1/[controller]")]

    [ApiController]

    public class CatlogManagementController : ControllerBase
    {
        private ICatlogBuisness _buisness;


        public CatlogManagementController(ICatlogBuisness buisness)
        {
            _buisness = buisness;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetProducts()
        {

            var products = await _buisness.GetProducts();
            return Ok(products);
        }
        [HttpPost("CreateProduct")]
        //[Route("[Create]")]

        [ProducesResponseType(typeof(Product), (int)System.Net.HttpStatusCode.Created)]

        public async Task CreateProducts([FromBody] Product product)
        {
            await _buisness.CreateProduct(product);
        }

        [HttpGet("GetProductById/{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult> GetProduct(string id)
        {
            var product = await _buisness.GetProductByid(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<ActionResult> GetProductByName(string category)
        {
            return Ok(await _buisness.GetProductBycategory(category));

        }
        [HttpDelete("DeleteProductById/{id:length(24)}")]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _buisness.DeleteProductByid(id));

        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductById(Product value)
        {
            return Ok(await _buisness.Updateproduct(value));
        }
        /*









        */
    }
}