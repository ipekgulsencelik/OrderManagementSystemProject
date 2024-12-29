using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface ICashBoxRepository : IRepository<CashBox>
    {
        decimal TotalCashBox();
    }
}