using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;

namespace VueSPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataProducts _DataProducts;

        public ProductsController(IDataProducts dataProducts)
        {
            _DataProducts = dataProducts;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollections<ProductsDto>>> GetAll(int page, int take = 20)
        {
            return await _DataProducts.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProductById(int id)
        {
            return await _DataProducts.GetProductById(id);
        } 

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductsDto body)
        {
            var result = await _DataProducts.CreateProduct(body);

            // Retorna un 201
            return CreatedAtAction(
                "GetProductById",
                new { id = result.IdProduct },
                result
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductsDto body)
        {
            await _DataProducts.UpdateProduct(id, body);

            // Retorna un 204
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            await _DataProducts.RemoveProduct(id);

            return NoContent();
        }
    }
}