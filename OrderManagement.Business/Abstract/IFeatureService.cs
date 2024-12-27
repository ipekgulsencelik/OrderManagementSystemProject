using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}