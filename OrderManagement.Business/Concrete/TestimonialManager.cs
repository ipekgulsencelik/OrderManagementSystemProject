using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialManager(IRepository<Testimonial> _repository, ITestimonialRepository testimonialRepository) : base(_repository)
        {
            _testimonialRepository = testimonialRepository;
        }
    }
}