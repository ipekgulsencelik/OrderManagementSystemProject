using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(OrderManagementContext context) : base(context)
        {
        }

        public Contact GetLastContact()
        {
            return _context.Contacts.OrderByDescending(x => x.ContactID).FirstOrDefault();
        }
    }
}