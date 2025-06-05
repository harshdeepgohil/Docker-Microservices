using AutoMapper;
using Product.Services.ProductAPI.Models;
using Product.Services.ProductAPI.Models.DTO;

namespace Product.Services.ProductAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Products,ProductsViewModel>().ReverseMap();
        }
    }
}
