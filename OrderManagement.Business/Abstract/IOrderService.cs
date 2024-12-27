using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        void TChangeStatus(int id);
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodaysTotalPrice();
    }
}