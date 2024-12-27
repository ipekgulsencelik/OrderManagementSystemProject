using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        void TChangeStatus(int id);
    }
}