using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}