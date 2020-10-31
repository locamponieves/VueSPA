using AutoMapper;
using Business.Commons;
using Models;
using Models.Dto;

namespace VueSPA.Config
{
    // Sirve para configurar nuestros mapeos
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Clients, ClientsDto>();
            CreateMap<DataCollections<Clients>, DataCollections<ClientsDto>>();

            CreateMap<Products, ProductsDto>();
            CreateMap<DataCollections<Products>, DataCollections<ProductsDto>>();

            CreateMap<Orders, OrdersDto>();
            CreateMap<DetailOrders, DetailOrdersDto>();
            CreateMap<DataCollections<Orders>, DataCollections<OrdersDto>>();
        }
    }
}