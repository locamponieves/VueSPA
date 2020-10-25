using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;

namespace VueSPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDataClients _DataClients;

        public ClientsController(IDataClients dataClients)
        {
            _DataClients = dataClients;
        }

        // Ex: clients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientsDto>> GetClientById(int id)
        {
            return await _DataClients.GetClientById(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient(ClientsDto body)
        {
            await _DataClients.CreateClient(body);

            return Ok();
        }
    }
}