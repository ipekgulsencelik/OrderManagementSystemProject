using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.AboutDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IMapper _mapper, IAboutService _aboutService, IValidator<CreateAboutDTO> _createAboutValidator) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _aboutService.TGetList();
            var result = _mapper.Map<List<ResultAboutDTO>>(values);
            return Ok(result);
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout()
        {
            var values = _aboutService.TGetLastAbout();
            var about = _mapper.Map<ResultAboutDTO>(values);
            return Ok(about);
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
    }
}