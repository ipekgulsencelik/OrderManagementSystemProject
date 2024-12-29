using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IRestaurantTableService : IGenericService<RestaurantTable>
    {
        void TChangeStatus(int id);
    }
}