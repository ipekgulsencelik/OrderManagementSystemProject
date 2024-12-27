using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        void TChangeStatus(int id);
    }
}