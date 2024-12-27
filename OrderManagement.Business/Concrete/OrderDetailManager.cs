using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class OrderDetailManager : GenericManager<OrderDetail>, IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IRepository<OrderDetail> _repository, IOrderDetailRepository orderDetailRepository) : base(_repository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void TChangeStatus(int id)
        {
            _orderDetailRepository.ChangeStatus(int id);
        }
    }
}