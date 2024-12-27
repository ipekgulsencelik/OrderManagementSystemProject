using AutoMapper;
using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<ResultProductDTO, Product>().ReverseMap();
            CreateMap<ResultProductWithCategoryDTO, Product>().ReverseMap();
        }
    }
}