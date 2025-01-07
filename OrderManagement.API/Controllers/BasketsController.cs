using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService _basketService, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetBasketByTable(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);
        }

        [HttpGet("GetBasketListByTableWithProductName/{id}")]
        public IActionResult GetBasketListByTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketListByTableWithProductName(id);
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetBasket()
        {
            var values = _basketService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDTO createBasketDTO)
        {
            var newBasket = mapper.Map<Basket>(createBasketDTO);
            newBasket.Quantity = 1;
            _basketService.TCreate(newBasket);
            return Ok("Sepete Ürün Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBasketItem(int id)
        {
            _basketService.TDelete(id);
            return Ok("Sepetten Ürün Silindi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBasket(int id, UpdateBasketDTO updateBasketDTO)
        {
            if (updateBasketDTO == null || updateBasketDTO.BasketID <= 0 || updateBasketDTO.Quantity < 1)
            {
                return BadRequest(new { Message = "Geçersiz sepet verisi." });
            }

            // Get the basket item by its ID
            var existingBasket = _basketService.TGetByID(id);
            if (existingBasket == null)
            {
                return NotFound(new { Message = "Sepet bulunamadı." });
            }

            // Update the basket item's quantity and price
            existingBasket.Quantity = updateBasketDTO.Quantity;

            // Save the updated basket to the database
            _basketService.TUpdate(existingBasket);

            return Ok(new { Message = "Sepet başarıyla güncellendi." });
        }
    }
}