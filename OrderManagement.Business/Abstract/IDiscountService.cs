using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}