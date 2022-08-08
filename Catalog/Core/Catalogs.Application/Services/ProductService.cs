using AutoMapper;
using Catalogs.Application.Interface.DTO;
using Catalogs.Application.Interface.Interfaces;
using Catalogs.Domain.Entities;
using Catalogs.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> products =  await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetPaged(int pageSize, int page)
        {
            IEnumerable<Product> products = await _productRepository.GetPaged(pageSize, page);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<bool> CheckStock(List<StockDTO> stockDTOs)
        {


            return false;
        }
    }
}
