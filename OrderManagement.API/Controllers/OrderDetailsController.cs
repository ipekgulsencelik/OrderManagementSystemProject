using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.OrderDetailDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(IOrderDetailService _orderDetailService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _mapper.Map<List<ResultOrderDetailDTO>>(_orderDetailService.TGetList());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderDetailService.TDelete(id);
            return Ok("Sipariş Detayı Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _orderDetailService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDetailDTO createOrderDetailDTO)
        {
            var newOrderDetail = _mapper.Map<OrderDetail>(createOrderDetailDTO);
            _orderDetailService.TCreate(newOrderDetail);
            return Ok("Sipariş Detayı başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateOrderDetailDTO updateOrderDetailDTO)
        {
            var OrderDetail = _mapper.Map<OrderDetail>(updateOrderDetailDTO);
            _orderDetailService.TUpdate(OrderDetail);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _orderDetailService.TCount();
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _orderDetailService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}