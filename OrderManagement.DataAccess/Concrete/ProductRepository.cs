using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OrderManagementContext context) : base(context)
        {
        }

        public List<ResultProductWithCategoryDTO> GetProductsWithCategories()
        {
            return _context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDTO
            {
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                IsShown = y.IsShown,
                Status = y.Status,
                Description = y.Description,
                CategoryName = y.Category.CategoryName,
            }).ToList();
        }
    }
}