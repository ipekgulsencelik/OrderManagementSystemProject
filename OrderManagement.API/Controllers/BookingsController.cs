using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.BookingDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IMapper _mapper, IBookingService _bookingService, IValidator<CreateBookingDTO> _validator) : ControllerBase
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
            var validationResult = _validator.Validate(createBookingDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDTO);
            _bookingService.TCreate(value);
            return Ok("Yeni Rezervasyon Yapıldı");
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

        [HttpGet("BookingApproved/{id}")]
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingApproved(id);
            return Ok("Rezervasyon Durumu Değiştirildi.");
        }

        [HttpGet("BookingCancelled/{id}")]
        public IActionResult BookingCancelled(int id)
        {
            _bookingService.TBookingCancelled(id);
            return Ok("Rezervasyon Durumu Değiştirildi.");
        }
    }
}