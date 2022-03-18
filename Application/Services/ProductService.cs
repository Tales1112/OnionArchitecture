using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task Add(ProductDTO product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            await _productRepository.Create(mapProduct);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var result = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var result = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(ProductDTO product)
        {
            var mapProduct = await _productRepository.GetById(product.Id);
            await _productRepository.Remove(mapProduct);
        }

        public async Task Update(ProductDTO product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            await _productRepository.Update(mapProduct);
        }
    }
}
