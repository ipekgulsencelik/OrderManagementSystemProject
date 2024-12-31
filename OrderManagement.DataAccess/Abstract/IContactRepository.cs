using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetLastContact();
    }
}