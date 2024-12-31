using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingApproved(int id);
        void TBookingCancelled(int id);
    }
}