using System.Linq.Expressions;

namespace OrderManagement.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetByID(int id);
        List<T> GetList();
        T GetByFilter(Expression<Func<T, bool>> predicate);
        List<T> GetFilteredList(Expression<Func<T, bool>> predicate);
        int Count();
        int FilteredCount(Expression<Func<T, bool>> predicate);
    }
}
