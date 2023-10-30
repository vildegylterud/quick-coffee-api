using AutoMapper;
using quick_coffee_api.Features.ProductTypes.Models;

namespace quick_coffee_api.Features.ProductTypes;


    public class ProductTypeMapping : Profile
    {
        public ProductTypeMapping()
        {
            CreateMap<ProductTypeDto, ProductTypeDocument>()
                .ForMember(dest => dest.Pk, opt => opt.Ignore())
                .ReverseMap();
        
        }
    }
