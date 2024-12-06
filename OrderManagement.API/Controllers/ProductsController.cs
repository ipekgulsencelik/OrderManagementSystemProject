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
    }
}