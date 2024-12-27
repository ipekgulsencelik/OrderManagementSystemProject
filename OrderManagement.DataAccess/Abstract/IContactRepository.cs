using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}