using AutoMapper;
using ProductManagementSystem.BAL.DTOs;
using ProductManagementSystem.DAL;

namespace ProductManagementSystem.BAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from Product (DAL) to ProductDto (BAL)
            CreateMap<Product, ProductDto>();

            // Map from CreateProductDto (BAL) to Product (DAL)
            CreateMap<CreateProductDto, Product>();

            // Map from UpdateProductDto (BAL) to Product (DAL)
            CreateMap<UpdateProductDto, Product>();
        }
    }
}