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

        public void ChangeStatus(int id)
        {
            var value = _context.Abouts.Find(id);
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

        public void DontShowOnHome(int id)
        {
            var value = _context.Abouts.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public About GetLastAbout()
        {
            return _context.Abouts.Where(x => x.IsShown && x.Status).OrderByDescending(x => x.AboutID).FirstOrDefault();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Abouts.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}