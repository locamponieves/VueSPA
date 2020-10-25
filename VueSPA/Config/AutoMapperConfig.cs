using AutoMapper;
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
        }
    }
}