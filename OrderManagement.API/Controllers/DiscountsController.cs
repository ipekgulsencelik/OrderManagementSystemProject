using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.DiscountDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IMapper _mapper, IDiscountService _discountService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _discountService.TGetList();
            var result = _mapper.Map<List<ResultDiscountDTO>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _discountService.TDelete(id);
            return Ok("İndirim Kodu Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountDTO createDiscountDTO)
        {
            var newValue = _mapper.Map<Discount>(createDiscountDTO);
            newValue.Status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _discountService.TCreate(newValue);
            return Ok("Yeni İndirim Kodu Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateDiscountDTO updateDiscountDTO)
        {
            var value = _mapper.Map<Discount>(updateDiscountDTO);
            value.Status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _discountService.TUpdate(value);
            return Ok("İndirim Kodu Güncellendi");
        }

        [HttpGet("GetActiveDiscounts")]
        public IActionResult GetActiveDiscounts()
        {
            var values = _discountService.TGetFilteredList(x => x.Status == true);
            var actives = _mapper.Map<List<ResultDiscountDTO>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassiveDiscounts")]
        public IActionResult GetPassiveDiscounts()
        {
            var values = _discountService.TGetFilteredList(x => x.Status == false);
            var passives = _mapper.Map<List<ResultDiscountDTO>>(values);
            return Ok(passives);
        }

    }
}