using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(OrderManagementContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var value = _context.Discounts.Find(id);
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

        public void DontShowOnHome(int id)
        {
            var value = _context.Discounts.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Discount> GetLast2ActiveDiscounts()
        {
            return _context.Discounts?.AsNoTracking().Where(x => x.IsShown && x.Status).OrderByDescending(x => x.DiscountID).Take(2).ToList() ?? new List<Discount>();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Discounts.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}