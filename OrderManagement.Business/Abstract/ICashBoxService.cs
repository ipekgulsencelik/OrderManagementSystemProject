using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface ICashBoxService : IGenericService<CashBox>
    {
        decimal TTotalCashBox();
    }
}