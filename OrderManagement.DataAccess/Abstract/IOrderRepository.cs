using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        void ChangeStatus(int id);
        int TotalOrderCount();
        int ActiveOrderCount();
        decimal LastOrderPrice();
        decimal TodaysTotalPrice();
    }
}