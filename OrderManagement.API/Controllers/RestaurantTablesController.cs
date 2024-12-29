using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.RestaurantTableDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTablesController(IRestaurantTableService _restaurantTableService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _mapper.Map<List<ResultRestaurantTableDTO>>(_restaurantTableService.TGetList());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateRestaurantTableDTO createRestaurantTableDTO)
        {
            var newTable = _mapper.Map<RestaurantTable>(createRestaurantTableDTO);
            newTable.Status = false;
            _restaurantTableService.TCreate(newTable);
            return Ok("Yeni Masa Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateRestaurantTableDTO updateRestaurantTableDTO)
        {
            var table = _mapper.Map<RestaurantTable>(updateRestaurantTableDTO);
            table.Status = false;
            _restaurantTableService.TUpdate(table);
            return Ok("Masa Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _restaurantTableService.TDelete(id);
            return Ok("Masa Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _restaurantTableService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _restaurantTableService.TCount();
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _restaurantTableService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}