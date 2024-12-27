using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ResultProductWithCategoryDTO> TGetProductsWithCategories();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
        double TAvgProductPrice();
        double TAvgHamburgerPrice();
        string TMostExpensiveProduct();
        string TCheapestProduct();
    }
}