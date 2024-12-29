using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.SocialMediaDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(ISocialMediaService _socialMediaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _socialMediaService.TGetList();
            var result = _mapper.Map<List<ResultSocialMediaDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDTO createSocialMediaDTO)
        {
            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _socialMediaService.TCreate(newValue);
            return Ok("Yeni Sosyal Medya Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }

        [HttpGet("GetActiveSocialMedias")]
        public IActionResult GetActiveSocialMedias()
        {
            var values = _socialMediaService.TGetFilteredList(x => x.Status && x.IsShown);
            var actives = _mapper.Map<List<ResultSocialMediaDTO>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassiveSocialMedias")]
        public IActionResult GetPassiveSocialMedias()
        {
            var values = _socialMediaService.TGetFilteredList(x => x.Status == false);
            var passives = _mapper.Map<List<ResultSocialMediaDTO>>(values);
            return Ok(passives);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _socialMediaService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _socialMediaService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _socialMediaService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}