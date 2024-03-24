using AutoMapper;
using WepAppJun.infrastructure.DTOs;
using WepAppJun.infrastructure.Models;

namespace WepAppJun.Api.View.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap <Product, ProductDto>();
            CreateMap <ProductDto, Product>();
        }
    }
}
