using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(OrderManagementContext context) : base(context)
        {
        }
    }
}