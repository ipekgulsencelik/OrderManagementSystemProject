using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class RestaurantTableManager : GenericManager<RestaurantTable>, IRestaurantTableService
    {
        private readonly IRestaurantTableRepository _restaurantTableRepository;

        public RestaurantTableManager(IRepository<RestaurantTable> _repository, IRestaurantTableRepository restaurantTableRepository) : base(_repository)
        {
            _restaurantTableRepository = restaurantTableRepository;
        }

        public void TChangeStatus(int id)
        {
            _restaurantTableRepository.ChangeStatus(id);
        }
    }
}