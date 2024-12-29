using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface ISliderService : IGenericService<Slider>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}