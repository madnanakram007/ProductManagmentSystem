using AutoMapper;
using ProductManagementSystem.BAL.DTOs;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DAL;
using ProductManagementSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            // Business Logic: validation
            if (createProductDto == null) throw new ArgumentNullException(nameof(createProductDto));
            if (createProductDto.Price <= 0) throw new ArgumentException("Price must be positive.", nameof(createProductDto.Price));

            var productEntity = _mapper.Map<Product>(createProductDto);
            productEntity.CreatedDate = DateTime.UtcNow; // Set creation date

            await _productRepository.AddAsync(productEntity);
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null) return false; // Or throw exception

            _productRepository.Delete(productEntity);
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var productEntities = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productEntities);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null) return false;

            // Use AutoMapper to update the existing entity from the DTO
            _mapper.Map(updateProductDto, productEntity);

            _productRepository.Update(productEntity);
            return await _productRepository.SaveChangesAsync();
        }
    }
}