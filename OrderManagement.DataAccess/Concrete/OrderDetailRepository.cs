using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(OrderManagementContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var value = _context.OrderDetails.Find(id);
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
    }
}