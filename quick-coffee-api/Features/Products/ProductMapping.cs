using AutoMapper;
using quick_coffee_api.Features.Products.Models;

namespace quick_coffee_api.Features.Products;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<ProductDto, ProductDocument>()
            .ForMember(dest => dest.Pk, opt => opt.Ignore())
            //.ForMember(dest => dest.ExtraProduct, opt => opt.MapFrom(src => src.ExtraProduct))
            .ReverseMap();
        
    }
}