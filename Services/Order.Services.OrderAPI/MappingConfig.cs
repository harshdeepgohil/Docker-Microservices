using AutoMapper;
using Order.Services.OrderAPI.Models;
using Order.Services.OrderAPI.Models.DTO;

namespace Order.Services.OrderAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 
            CreateMap<OrdersViewModel,Orders>().ReverseMap();
        }
    }
}
