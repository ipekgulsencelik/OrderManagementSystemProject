using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class CashBoxRepository : GenericRepository<CashBox>, ICashBoxRepository
    {
        public CashBoxRepository(OrderManagementContext context) : base(context)
        {
        }

        public decimal TotalCashBox()
        {
            return _context.CashBoxes.Sum(x => x.TotalAmount);
        }
    }
}