using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class SocialMediaManager : GenericManager<SocialMedia>, ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaManager(IRepository<SocialMedia> _repository, ISocialMediaRepository socialMediaRepository) : base(_repository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _socialMediaRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _socialMediaRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _socialMediaRepository.ChangeStatus(id);
        }
    }
}