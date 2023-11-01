using AutoMapper;
using quick_coffee_api.Features.ExtraProducts.Models;

namespace quick_coffee_api.Features.ExtraProducts;

public class ExtraProductsMapping : Profile
{

    public ExtraProductsMapping()
    {
        CreateMap<ExtraProductDto, ExtraProductDocument>()
            .ForMember(dest => dest.Pk, opt => opt.Ignore())
            .ReverseMap();
    }
}