using AutoMapper;
using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries.Interfaces;
using CatalogPersistanceDatabase;
using Common.Collection;
using Common.Paging;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductQueryService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var colletion = await _context.Products
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderByDescending(x => x.ProductId)
                .GetPageAsync(page, take);

            var collectionDTO = _mapper.Map<DataCollection<ProductDTO>>(colletion);

            return collectionDTO;
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var product = await _context.Products.SingleAsync(x => x.ProductId == id);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }
    }
}