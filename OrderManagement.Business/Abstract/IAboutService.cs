using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        About TGetLastAbout();
    }
}