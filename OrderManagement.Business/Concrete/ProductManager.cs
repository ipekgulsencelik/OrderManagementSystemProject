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

        public void TDontShowOnHome(int id)
        {
            _productRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _productRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _productRepository.ChangeStatus(id);
        }

        public double TAvgProductPrice()
        {
            return _productRepository.AvgProductPrice();
        }

        public double TAvgHamburgerPrice()
        {
            return _productRepository.AvgHamburgerPrice();
        }

        public string TMostExpensiveProduct()
        {
            return _productRepository.MostExpensiveProduct();
        }

        public string TCheapestProduct()
        {
            return _productRepository.CheapestProduct();
        }
    }
}