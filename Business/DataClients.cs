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
        Task<ClientsDto> CreateClient(ClientsDto body);
        Task UpdateClient(int id, ClientsDto body);
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

        public async Task<ClientsDto> CreateClient(ClientsDto body)
        {
            var entry = new Clients
            {
                Name = body.Name  
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            // Retorno el objeto que ha sido procesado para la creación
            return _mapper.Map<ClientsDto>(entry);
        }

        public async Task UpdateClient(int id, ClientsDto body)
        {
            var entry = await _context.Clients.SingleAsync(x => x.IdClient == id);

            entry.Name = body.Name;

            await _context.SaveChangesAsync();
        }
    }
}