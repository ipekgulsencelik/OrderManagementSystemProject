using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IBasketRepository : IRepository<Basket>
    {
        List<Basket> GetBasketByTableNumber(int tableNumber);
        List<ResultBasketListWithProducts> GetBasketListByTableWithProductName(int id);
    }
}