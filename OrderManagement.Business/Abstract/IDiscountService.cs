using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        List<Discount> TGetLast2ActiveDiscounts();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}