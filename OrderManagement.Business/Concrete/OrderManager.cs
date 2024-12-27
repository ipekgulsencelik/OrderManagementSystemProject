using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class OrderManager : GenericManager<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IRepository<Order> _repository, IOrderRepository orderRepository) : base(_repository)
        {
            _orderRepository = orderRepository;
        }

        public int TActiveOrderCount()
        {
            return _orderRepository.ActiveOrderCount();
        }

        public void TChangeStatus(int id)
        {
            _orderRepository.ChangeStatus(id);
        }

        public decimal TLastOrderPrice()
        {
            return _orderRepository.LastOrderPrice();
        }

        public decimal TTodaysTotalPrice()
        {
            return _orderRepository.TodaysTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderRepository.TotalOrderCount();
        }
    }
}