using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class ContactManager : GenericManager<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IRepository<Contact> _repository, IContactRepository contactRepository) : base(_repository)
        {
            _contactRepository = contactRepository;
        }
    }
}