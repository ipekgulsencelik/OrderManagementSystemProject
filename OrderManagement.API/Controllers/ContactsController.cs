using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.ContactDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IMapper _mapper, IContactService _contactService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _contactService.TGetList();
            var result = _mapper.Map<List<ResultContactDTO>>(values);
            return Ok(result);
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact()
        {
            var values = _contactService.TGetLastContact();
            var contact = _mapper.Map<ResultContactDTO>(values);
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDTO createContactDTO)
        {
            var newValue = _mapper.Map<Contact>(createContactDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _contactService.TCreate(newValue);
            return Ok("Yeni İletişim Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDTO updateContactDTO)
        {
            var value = _mapper.Map<Contact>(updateContactDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _contactService.TUpdate(value);
            return Ok("İletişim Bilgisi Güncellendi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _contactService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _contactService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _contactService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}