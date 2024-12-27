using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderManagementContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public void ChangeStatus(int id)
        {
            var value = _context.Orders.Find(id);
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

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).Select(x => x.TotalPrice).FirstOrDefault();
        }

        public decimal TodaysTotalPrice()
        {
            return _context.Orders.Where(x => x.OrderDate.Date == DateTime.Today).Sum(x => x.TotalPrice);
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}