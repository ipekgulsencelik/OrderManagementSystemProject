using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> TGetUnreadNotifications();
        int TUnreadNotificationCount();
        int TReadNotificationCount();
        void TMarkAsRead(int id);
        void TMarkAsUnread(int id);
    }
}