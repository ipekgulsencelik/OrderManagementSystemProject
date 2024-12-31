using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class BookingManager : GenericManager<Booking>, IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IRepository<Booking> _repository, IBookingRepository bookingRepository) : base(_repository)
        {
            _bookingRepository = bookingRepository;
        }

        public void TBookingApproved(int id)
        {
            _bookingRepository.BookingApproved(id);
        }

        public void TBookingCancelled(int id)
        {
            _bookingRepository.BookingCancelled(id);
        }
    }
}