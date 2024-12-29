using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class BasketManager : GenericManager<Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketManager(IRepository<Basket> _repository, IBasketRepository basketRepository) : base(_repository)
        {
            _basketRepository = basketRepository;
        }

        public List<Basket> TGetBasketByTableNumber(int tableNumber)
        {
            return _basketRepository.GetBasketByTableNumber(tableNumber);
        }

        public List<ResultBasketListWithProducts> TGetBasketListByTableWithProductName(int id)
        {
            return _basketRepository.GetBasketListByTableWithProductName(id);
        }
    }
}