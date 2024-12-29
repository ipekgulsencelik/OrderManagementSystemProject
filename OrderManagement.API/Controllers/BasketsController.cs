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
            newBasket.RestaurantTableID = 4;
            _basketService.TCreate(newBasket);
            return Ok("Sepete Ürün Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBasketItem(int id)
        {
            _basketService.TDelete(id);
            return Ok("Sepetten Ürün Silindi");
        }
    }
}