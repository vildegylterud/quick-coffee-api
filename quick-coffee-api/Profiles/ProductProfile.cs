using AutoMapper;
using quick_coffee_api.Entities;
using quick_coffee_api.Models;

namespace quick_coffee_api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDocument, ProductDto>();
        CreateMap<ProductDto, ProductDocument>().
            ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Id));
    }
}