using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class DiscountManager : GenericManager<Discount>, IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountManager(IRepository<Discount> _repository, IDiscountRepository discountRepository) : base(_repository)
        {
            _discountRepository = discountRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _discountRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _discountRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _discountRepository.ChangeStatus(id);
        }
    }
}