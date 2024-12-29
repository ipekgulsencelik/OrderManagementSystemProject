using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.CashBoxDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxesController(ICashBoxService _cashBoxService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _cashBoxService.TGetList();
            var result = _mapper.Map<List<ResultCashBoxDTO>>(values);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cashBoxService.TDelete(id);
            return Ok("Kasa Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _cashBoxService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateCashBoxDTO createCashBoxDTO)
        {
            var newCashBox = _mapper.Map<CashBox>(createCashBoxDTO);
            _cashBoxService.TCreate(newCashBox);
            return Ok("Kasa Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCashBoxDTO updateCashBoxDTO)
        {
            var cashbox = _mapper.Map<CashBox>(updateCashBoxDTO);
            _cashBoxService.TUpdate(cashbox);
            return Ok("Kasa Başarıyla Güncellendi");
        }

        [HttpGet("TotalCashBox")]
        public IActionResult TotalCashBox()
        {
            var value = _cashBoxService.TTotalCashBox();
            return Ok(value);
        }
    }
}