using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface ISocialMediaService : IGenericService<SocialMedia>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}