using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}