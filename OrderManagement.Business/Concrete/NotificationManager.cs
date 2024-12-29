using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class NotificationManager : GenericManager<Notification>, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationManager(IRepository<Notification> _repository, INotificationRepository notificationRepository) : base(_repository)
        {
            _notificationRepository = notificationRepository;
        }

        public List<Notification> TGetUnreadNotifications()
        {
            return _notificationRepository.GetUnreadNotifications();
        }

        public void TMarkAsRead(int id)
        {
            _notificationRepository.MarkAsRead(id);
        }

        public void TMarkAsUnread(int id)
        {
            _notificationRepository.MarkAsUnread(id);
        }

        public int TReadNotificationCount()
        {
            return _notificationRepository.ReadNotificationCount();
        }

        public int TUnreadNotificationCount()
        {
            return _notificationRepository.UnreadNotificationCount();
        }
    }
}