using AutoMapper;
using Business.Commons;
using Business.Extensions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDataClients
    {
        Task<DataCollections<ClientsDto>> GetAll(int page, int take);
        Task<ClientsDto> GetClientById(int id);
        Task<ClientsDto> CreateClient(ClientsDto body);
        Task UpdateClient(int id, ClientsDto body);
        Task RemoveClient(int id);
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

        public async Task<DataCollections<ClientsDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollections<ClientsDto>>(
                await _context.Clients.OrderByDescending(x => x.IdClient)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
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

        public async Task RemoveClient(int id)
        {
            _context.Remove(new Clients {
                IdClient = id
            });

            await _context.SaveChangesAsync();
        }
    }
}