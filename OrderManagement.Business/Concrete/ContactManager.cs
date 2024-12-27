using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Concrete;
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

        public void TDontShowOnHome(int id)
        {
            _contactRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _contactRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _contactRepository.ChangeStatus(id);
        }
    }
}