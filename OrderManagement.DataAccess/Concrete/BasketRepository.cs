using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(OrderManagementContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int tableNumber)
        {
            return _context.Baskets.Where(x => x.RestaurantTableID == tableNumber).Include(y => y.Product).ToList();
        }

        public List<ResultBasketListWithProducts> GetBasketListByTableWithProductName(int id)
        {
            return _context.Baskets.Include(x => x.Product).Where(y => y.RestaurantTableID == id).Select(z => new ResultBasketListWithProducts
                          {
                              BasketID = z.BasketID,
                              Quantity = z.Quantity,
                              RestaurantTableID = z.RestaurantTableID,
                              Price = z.Product.Price,
                              ProductID = z.ProductID,
                              TotalPrice = z.TotalPrice,
                              ProductName = z.Product.ProductName
                          }).ToList();
        }
    }
}