using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface ITestimonialRepository : IRepository<Testimonial>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        void ChangeStatus(int id);
    }
}