using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IRepository<Product> _repository, IProductRepository productRepository) : base(_repository)
        {
            _productRepository = productRepository;
        }

        public List<ResultProductWithCategoryDTO> TGetProductsWithCategories()
        {
            return _productRepository.GetProductsWithCategories();
        }
    }
}