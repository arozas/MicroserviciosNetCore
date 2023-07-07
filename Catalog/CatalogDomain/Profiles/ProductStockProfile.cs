using AutoMapper;
using CatalogDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDomain.Profiles
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
