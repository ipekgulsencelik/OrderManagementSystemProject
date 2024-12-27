using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}