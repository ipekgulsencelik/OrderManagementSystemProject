using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class RestaurantTableRepository : GenericRepository<RestaurantTable>, IRestaurantTableRepository
    {
        public RestaurantTableRepository(OrderManagementContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var value = _context.RestaurantTables.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _context.Update(value);
            _context.SaveChanges();
        }
    }
}