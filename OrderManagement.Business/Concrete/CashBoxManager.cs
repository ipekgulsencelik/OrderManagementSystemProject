using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class CashBoxManager : GenericManager<CashBox>, ICashBoxService
    {
        private readonly ICashBoxRepository _cashBoxRepository;

        public CashBoxManager(IRepository<CashBox> _repository, ICashBoxRepository cashBoxRepository) : base(_repository)
        {
            _cashBoxRepository = cashBoxRepository;
        }

        public decimal TTotalCashBox()
        {
            return _cashBoxRepository.TotalCashBox();
        }
    }
}