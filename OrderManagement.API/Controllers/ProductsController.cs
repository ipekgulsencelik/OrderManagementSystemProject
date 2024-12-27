using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.ProductDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _mapper.Map<List<ResultProductDTO>>(_productService.TGetList());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO createProductDTO)
        {
            var newProduct = _mapper.Map<Product>(createProductDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _productService.TCreate(newProduct);
            return Ok("Yeni Ürün Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDTO updateProductDTO)
        {
            var product = _mapper.Map<Product>(updateProductDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _productService.TUpdate(product);
            return Ok("Ürün Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.TDelete(id);
            return Ok("Ürün Silindi");
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _productService.TCount();
            return Ok(value);
        }

        [HttpGet("GetActiveProducts")]
        public IActionResult GetActiveProducts()
        {
            var values = _productService.TFilteredCount(x => x.Status == true);
            var actives = _mapper.Map<List<ResultProductDTO>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassiveProducts")]
        public IActionResult GetPassiveProducts()
        {
            var values = _productService.TFilteredCount(x => x.Status == false);
            var passives = _mapper.Map<List<ResultProductDTO>>(values);
            return Ok(passives);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _productService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _productService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _productService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }

        [HttpGet("GetHamburgerCount")]
        public IActionResult GetHamburgerCount()
        {
            var value = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "hamburger");
            return Ok(value);
        }

        [HttpGet("GetDrinkCount")]
        public IActionResult GetDrinkCount()
        {
            var value = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "içecek");
            return Ok(value);
        }

        [HttpGet("GetAvgProductPrice")]
        public IActionResult GetAvgProductPrice()
        {
            var value = _productService.TAvgProductPrice();
            return Ok(value);
        }

        [HttpGet("GetCheapestProduct")]
        public IActionResult GetCheapestProduct()
        {
            var value = _productService.TCheapestProduct();
            return Ok(value);
        }

        [HttpGet("GetMostExpensiveProduct")]
        public IActionResult GetMostExpensiveProduct()
        {
            var value = _productService.TMostExpensiveProduct();
            return Ok(value);
        }

        [HttpGet("GetAvgHamburgerPrice")]
        public IActionResult GetAvgHamburgerPrice()
        {
            var value = _productService.TAvgHamburgerPrice();
            return Ok(value);
        }
    }
}