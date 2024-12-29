using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Abstract
{
    public interface INotificationRepository : IRepository<Notification>
    {
        List<Notification> GetUnreadNotifications();
        int UnreadNotificationCount();
        int ReadNotificationCount();
        void MarkAsRead(int id);
        void MarkAsUnread(int id);
    }
}