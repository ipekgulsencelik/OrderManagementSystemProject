using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class AboutManager : GenericManager<About>, IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutManager(IRepository<About> _repository, IAboutRepository aboutRepository) : base(_repository)
        {
            _aboutRepository = aboutRepository;
        }
    }
}