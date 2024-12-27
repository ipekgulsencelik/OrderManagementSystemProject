using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void ChangeStatus(int id);
    }
}