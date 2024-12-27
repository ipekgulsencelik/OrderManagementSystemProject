using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ResultProductWithCategoryDTO> GetProductsWithCategories();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
        double AvgProductPrice();
        double AvgHamburgerPrice();
        string MostExpensiveProduct();
        string CheapestProduct();
    }
}