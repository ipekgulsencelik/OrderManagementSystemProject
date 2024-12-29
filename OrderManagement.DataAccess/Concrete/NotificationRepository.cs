using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(OrderManagementContext context) : base(context)
        {
        }

        public List<Notification> GetUnreadNotifications()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }

        public void MarkAsRead(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = true;
            _context.Update(value);
            _context.SaveChanges();
        }

        public void MarkAsUnread(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = false;
            _context.Update(value);
            _context.SaveChanges();
        }

        public int ReadNotificationCount()
        {
            return _context.Notifications.Where(x => x.Status == true).Count();
        }

        public int UnreadNotificationCount()
        {
            return _context.Notifications.Where(x => x.Status == false).Count();
        }
    }
}