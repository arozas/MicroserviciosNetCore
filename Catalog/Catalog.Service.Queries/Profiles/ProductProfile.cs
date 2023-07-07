using AutoMapper;
using Catalog.Service.Queries.DTOs;
using CatalogDomain;

namespace Catalog.Service.Queries.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
