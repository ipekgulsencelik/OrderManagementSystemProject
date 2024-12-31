using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void BookingApproved(int id);
        void BookingCancelled(int id);
    }
}