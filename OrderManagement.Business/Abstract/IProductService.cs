using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ResultProductWithCategoryDTO> TGetProductsWithCategories();
    }
}