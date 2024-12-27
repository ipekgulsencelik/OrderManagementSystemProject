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

        public void ChangeStatus(int id)
        {
            var value = _context.Products.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _context.Update(value);
            _context.SaveChanges();
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Products.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Products.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }

        public double AvgProductPrice()
        {
            return Convert.ToDouble(_context.Products.Average(x => x.Price));
        }

        public double AvgHamburgerPrice()
        {
            return Convert.ToDouble(_context.Products.Where(x => x.Category.CategoryName.ToLower() == "hamburger").Average(x => x.Price));
        }

        public string MostExpensiveProduct()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Max(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();
        }

        public string CheapestProduct()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Min(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();
        }
    }
}