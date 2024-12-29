using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Contact TGetLastContact();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}