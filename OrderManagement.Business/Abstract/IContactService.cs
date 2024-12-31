using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Contact TGetLastContact();
    }
}