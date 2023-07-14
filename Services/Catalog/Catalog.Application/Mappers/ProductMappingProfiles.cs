using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers;

public class ProductMappingProfiles:Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
    }
}