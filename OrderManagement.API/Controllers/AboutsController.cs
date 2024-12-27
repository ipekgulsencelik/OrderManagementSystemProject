using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.AboutDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IMapper _mapper, IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _aboutService.TGetList();
            var result = _mapper.Map<List<ResultAboutDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımızda Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDTO createAboutDTO)
        {
            var newValue = _mapper.Map<About>(createAboutDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _aboutService.TCreate(newValue);
            return Ok("Yeni Hakkımızda Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDTO updateAboutDTO)
        {
            var value = _mapper.Map<About>(updateAboutDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _aboutService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _aboutService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _aboutService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}