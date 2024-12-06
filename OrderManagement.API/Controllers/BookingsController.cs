using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.BookingDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IMapper _mapper, IBookingService _bookingService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _bookingService.TGetList();
            var result = _mapper.Map<List<ResultBookingDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookingService.TDelete(id);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDTO createBookingDTO)
        {
            var newValue = _mapper.Map<Booking>(createBookingDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _bookingService.TCreate(newValue);
            return Ok("Yeni Rezervasyon Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBookingDTO updateBookingDTO)
        {
            var value = _mapper.Map<Booking>(updateBookingDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Güncellendi");
        }
    }
}