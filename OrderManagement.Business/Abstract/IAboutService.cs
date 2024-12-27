using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}