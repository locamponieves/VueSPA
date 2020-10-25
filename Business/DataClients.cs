using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDataClients
    {
        Task<ClientsDto> GetClientById(int id);
        Task CreateClient(ClientsDto body);
    }

    public class DataClients : IDataClients
    {
        private readonly DataContext _context;
        private readonly IMapper     _mapper;

        public DataClients(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        public async Task<ClientsDto> GetClientById(int id)
        {
            // con mapper se pasa de Clients a ClientsDto
            return _mapper.Map<ClientsDto>(
                await _context.Clients.SingleAsync(x => x.IdClient == id)
            );
        }

        public async Task CreateClient(ClientsDto body)
        {
            var entry = new Clients
            {
                Name = body.Name  
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}