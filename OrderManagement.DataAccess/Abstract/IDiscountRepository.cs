using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        List<Discount> GetLast2ActiveDiscounts();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}