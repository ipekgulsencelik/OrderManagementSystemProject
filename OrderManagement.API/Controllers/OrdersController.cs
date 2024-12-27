using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.OrderDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService _orderService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _mapper.Map<List<ResultOrderDTO>>(_orderService.TGetList());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.TDelete(id);
            return Ok("Sipariş Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _orderService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDTO createOrderDTO)
        {
            var newOrder = _mapper.Map<Order>(createOrderDTO);
            _orderService.TCreate(newOrder);
            return Ok("Sipariş başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateOrderDTO updateOrderDTO)
        {
            var order = _mapper.Map<Order>(updateOrderDTO);
            _orderService.TUpdate(order);
            return Ok("Sipariş başarıyla güncellendi");
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _orderService.TCount();
            return Ok(value);
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodaysTotalPrice")]
        public IActionResult TodaysTotalPrice()
        {
            return Ok(_orderService.TTodaysTotalPrice());
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _orderService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}