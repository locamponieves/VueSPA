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
    public interface IDataProducts
    {
        Task<DataCollections<ProductsDto>> GetAll(int page, int take);
        Task<ProductsDto> GetProductById(int id);
        Task<ProductsDto> CreateProduct(ProductsDto body);
        Task UpdateProduct(int id, ProductsDto body);
        Task RemoveProduct(int id);
    }

    public class DataProducts : IDataProducts
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DataProducts(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollections<ProductsDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollections<ProductsDto>>(
                await _context.Products.OrderByDescending(x => x.IdProduct)
                              .AsQueryable()
                              .PagedAsync(page, take)
            );
        }

        public async Task<ProductsDto> GetProductById(int id)
        {
            return _mapper.Map<ProductsDto>(
                await _context.Products.SingleAsync(x => x.IdProduct == id)
            );
        }

        public async Task<ProductsDto> CreateProduct(ProductsDto body)
        {
            var entry = new Products
            {
                Name        = body.Name,
                Price       = body.Price,
                Description = body.Description
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductsDto>(entry);
        }

        public async Task UpdateProduct(int id, ProductsDto body)
        {
            var entry = await _context.Products.SingleAsync(x => x.IdProduct == id);

            entry.Name        = body.Name;
            entry.Price       = body.Price;
            entry.Description = body.Description;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveProduct(int id)
        {
            _context.Remove(new Products
            {
                IdProduct = id
            });

            await _context.SaveChangesAsync();
        }
    }
}