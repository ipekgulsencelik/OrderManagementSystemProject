using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        List<Feature> TGetLast3Features();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}