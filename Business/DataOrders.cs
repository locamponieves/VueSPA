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
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDataOrders
    {
        Task<DataCollections<OrdersDto>> GetAll(int page, int take);
        Task<OrdersDto> GetOrderById(int id);
        Task<OrdersDto> CreateOrder(OrdersDto body);
    }

    public class DataOrders : IDataOrders
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private const decimal IvaRate = 0.18m;

        public DataOrders(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        public async Task<DataCollections<OrdersDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollections<OrdersDto>>(
                await _context.Orders.OrderByDescending(x => x.IdOrder)
                                     .Include(x => x.Client)
                                     .Include(x => x.ListDetailOrders)
                                     .ThenInclude(x => x.Products)
                                     .AsQueryable()
                                     .PagedAsync(page, take)
            );
        }

        public async Task<OrdersDto> GetOrderById(int id)
        {
            return _mapper.Map<OrdersDto>(
                await _context.Orders
                    .Include(x => x.Client)
                    .Include(x => x.ListDetailOrders)
                    .ThenInclude(x => x.Products)
                    .SingleAsync(x => x.IdOrder == id)

            );
        }

        public async Task<OrdersDto> CreateOrder(OrdersDto body)
        {
            var entry = _mapper.Map<Orders>(body);

            // Prepare order detail
            PrepareDetail(entry.ListDetailOrders);

            // Prepare order header
            PrepareHeader(entry);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrdersDto>(
                await GetOrderById(entry.IdOrder)
            );
        }

        // Calcula los montos
        private void PrepareDetail(IEnumerable<DetailOrders> body)
        {
            foreach (var item in body)
            {
                item.Total    = item.UnitPrice * item.Quantity;
                item.Iva      = item.Total * IvaRate;
                item.SubTotal = item.Total - item.Iva;
            }
        }

        private void PrepareHeader(Orders body)
        {
            body.SubTotal = body.ListDetailOrders.Sum(x => x.SubTotal);
            body.Iva      = body.ListDetailOrders.Sum(x => x.Iva);
            body.Total    = body.ListDetailOrders.Sum(x => x.Total);
        }
    }
}