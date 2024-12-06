using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IRepository<Category> _repository, ICategoryRepository categoryRepository) : base(_repository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}