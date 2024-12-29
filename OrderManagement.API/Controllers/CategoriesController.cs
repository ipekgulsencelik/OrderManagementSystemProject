using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.CategoryDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMapper _mapper, ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _categoryService.TGetList();
            var result = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO createCategoryDTO)
        {
            var newValue = _mapper.Map<Category>(createCategoryDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _categoryService.TCreate(newValue);
            return Ok("Yeni Kategori Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var value = _mapper.Map<Category>(updateCategoryDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi");
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var value = _categoryService.TCount();
            return Ok(value);
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var value = _categoryService.TGetFilteredList(x => x.Status && x.IsShown);
            return Ok(value);
        }

        [HttpGet("GetPassiveCategories")]
        public IActionResult GetPassiveCategories()
        {
            var value = _categoryService.TGetFilteredList(x => x.Status == false);
            return Ok(value);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _categoryService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _categoryService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _categoryService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}