using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ResultProductWithCategoryDTO> GetProductsWithCategories();
    }
}