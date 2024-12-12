using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}