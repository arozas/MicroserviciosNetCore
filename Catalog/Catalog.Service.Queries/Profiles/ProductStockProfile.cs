using AutoMapper;
using Catalog.Service.Queries.DTOs;
using CatalogDomain;

namespace Catalog.Service.Queries.Profiles
{
    public class ProductStockProfile : Profile
    {
        public ProductStockProfile()
        {
            CreateMap<ProductStock, ProductStockDTO>();
            CreateMap<ProductStockDTO, ProductStock>();
        }
    }
}
