using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IRestaurantTableRepository : IRepository<RestaurantTable>
    {
        void ChangeStatus(int id);
    }
}