﻿using System;
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
    public class ClientsController : ControllerBase
    {
        private readonly IDataClients _DataClients;

        public ClientsController(IDataClients dataClients)
        {
            _DataClients = dataClients;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollections<ClientsDto>>> GetAll(int page, int take = 20)
        {
            return await _DataClients.GetAll(page, take);
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
            var result = await _DataClients.CreateClient(body);

            // Retorna un 201
            return CreatedAtAction(
                "GetClientById",
                new {id = result.IdClient},
                result
            );
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, ClientsDto body)
        {
            await _DataClients.UpdateClient(id, body);

            // Retorna un 204
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveClient(int id)
        {
            await _DataClients.RemoveClient(id);

            return NoContent();
        }
    }
}