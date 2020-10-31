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
    public class OrdersController : ControllerBase
    {
        private readonly IDataOrders _DataOrders;

        public OrdersController(IDataOrders dataOrders)
        {
            _DataOrders = dataOrders;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollections<OrdersDto>>> GetAll(int page, int take = 20)
        {
            return await _DataOrders.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDto>> GetOrderById(int id)
        {
            return await _DataOrders.GetOrderById(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrdersDto body)
        {
            var result = await _DataOrders.CreateOrder(body);

            // Retorna un 201
            return CreatedAtAction(
                "GetOrderById",
                new { id = result.IdOrder },
                result
            );
        }
    }
}