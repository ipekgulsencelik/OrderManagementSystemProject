using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.SliderDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController(IMapper _mapper, ISliderService _sliderService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _sliderService.TGetList();
            var result = _mapper.Map<List<ResultSliderDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sliderService.TDelete(id);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateSliderDTO createSliderDTO)
        {
            var newValue = _mapper.Map<Slider>(createSliderDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _sliderService.TCreate(newValue);
            return Ok("Yeni Öne Çıkan Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateSliderDTO updateSliderDTO)
        {
            var value = _mapper.Map<Slider>(updateSliderDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _sliderService.TUpdate(value);
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("GetSliderCount")]
        public IActionResult GetSliderCount()
        {
            var value = _sliderService.TCount();
            return Ok(value);
        }

        [HttpGet("GetActiveSliders")]
        public IActionResult GetActiveSliders()
        {
            var value = _sliderService.TFilteredCount(x => x.Status == true);
            return Ok(value);
        }

        [HttpGet("GetPassiveSliders")]
        public IActionResult GetPassiveSliders()
        {
            var value = _sliderService.TFilteredCount(x => x.Status == false);
            return Ok(value);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _sliderService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _sliderService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _sliderService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}