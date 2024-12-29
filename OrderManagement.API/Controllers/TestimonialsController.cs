using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.TestimonialDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _testimonialService.TGetList();
            var result = _mapper.Map<List<ResultTestimonialDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDTO createTestimonialDTO)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _testimonialService.TCreate(newValue);
            return Ok("Yeni Referans Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _testimonialService.TUpdate(value);
            return Ok("Referans Güncellendi");
        }

        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialService.TGetFilteredList(x => x.Status && x.IsShown);
            var actives = _mapper.Map<List<ResultTestimonialDTO>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassiveTestimonials")]
        public IActionResult GetPassiveTestimonials()
        {
            var values = _testimonialService.TGetFilteredList(x => x.Status == false);
            var passives = _mapper.Map<List<ResultTestimonialDTO>>(values);
            return Ok(passives);
        }

        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var courseCount = _testimonialService.TCount();
            return Ok(courseCount);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _testimonialService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _testimonialService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _testimonialService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}