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
    }
}