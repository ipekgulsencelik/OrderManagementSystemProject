using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IAboutRepository : IRepository<About>
    {
        About GetLastAbout();
    }
}