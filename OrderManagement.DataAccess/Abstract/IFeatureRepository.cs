using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}