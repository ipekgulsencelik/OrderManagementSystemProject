using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class SliderManager : GenericManager<Slider>, ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderManager(IRepository<Slider> _repository, ISliderRepository sliderRepository) : base(_repository)
        {
            _sliderRepository = sliderRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _sliderRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _sliderRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _sliderRepository.ChangeStatus(id);
        }
    }
}