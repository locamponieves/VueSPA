using DataAccess;
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
        Task CreateClient(ClientsDto body);
    }

    public class DataClients : IDataClients
    {
        private readonly DataContext _context;

        public DataClients(DataContext context)
        {
            _context = context;
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