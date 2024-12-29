using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByTableNumber(int tableNumber);
        List<ResultBasketListWithProducts> TGetBasketListByTableWithProductName(int id);
    }
}