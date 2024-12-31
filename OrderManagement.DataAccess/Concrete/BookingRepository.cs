using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(OrderManagementContext context) : base(context)
        {
        }

        public void BookingApproved(int id)
        {
            var values = _context.Bookings.Find(id);
            values.ReservationStatus = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }

        public void BookingCancelled(int id)
        {
            var values = _context.Bookings.Find(id);
            values.ReservationStatus = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }
    }
}