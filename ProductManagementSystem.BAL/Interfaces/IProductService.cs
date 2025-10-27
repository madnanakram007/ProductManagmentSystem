using ProductManagementSystem.BAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem.BAL.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
    }
}