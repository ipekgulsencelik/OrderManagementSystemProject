using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.UI.DTOs.BasketDTOs;
using OrderManagement.UI.Helpers;
using CreateBasketDTO = OrderManagement.UI.DTOs.BasketDTOs.CreateBasketDTO;

namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Geçersiz masa ID." });
            }

            TempData["id"] = id;

            try
            {
                var values = await client.GetFromJsonAsync<List<ResultBasketDTO>>(
                    $"Baskets/GetBasketListByTableWithProductName/{id}");

                if (values == null || !values.Any())
                {
                    ViewBag.Message = "Bu masaya ait sepet bilgisi bulunamadı.";
                    return View(new List<ResultBasketDTO>());
                }

                return View(values);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir mesaj döndürülmesi
                ViewBag.ErrorMessage = "Sepet bilgileri yüklenirken bir hata oluştu.";
                ViewBag.ErrorDetails = ex.Message;
                return View(new List<ResultBasketDTO>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] CreateBasketDTO createBasketDTO)
        {
            if (createBasketDTO == null || createBasketDTO.RestaurantTableID <= 0 || createBasketDTO.ProductID <= 0)
            {
                return BadRequest(new { Message = "Eksik veya geçersiz giriş verisi." });
            }

            try
            {
                var basketResponse = await client.PostAsJsonAsync("Baskets", createBasketDTO);
                var tableResponse = await client.GetAsync($"RestaurantTables/ChangeStatus/{createBasketDTO.RestaurantTableID}");

                if (basketResponse.IsSuccessStatusCode && tableResponse.IsSuccessStatusCode)
                {
                    return NoContent();
                }

                return StatusCode(500, new
                {
                    Message = "İşlem sırasında bir hata oluştu.",
                    BasketError = !basketResponse.IsSuccessStatusCode
                        ? await basketResponse.Content.ReadAsStringAsync()
                        : null,
                    TableError = !tableResponse.IsSuccessStatusCode
                        ? await tableResponse.Content.ReadAsStringAsync()
                        : null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Sunucu hatası.", ErrorDetails = ex.Message });
            }
        }

        public async Task<IActionResult> RemoveBasketItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Geçersiz sepet öğesi ID." });
            }

            try
            {
                var response = await client.DeleteAsync($"Baskets/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = "Sepet öğesi silinirken bir hata oluştu.";
                    return RedirectToAction("Index", new { id = TempData["id"] });
                }

                return RedirectToAction("Index", new { id = TempData["id"] });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Sunucu hatası: {ex.Message}";
                return RedirectToAction("Index", new { id = TempData["id"] });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateBasketDTO updateBasketDTO)
        {
            if (updateBasketDTO == null || updateBasketDTO.BasketID <= 0 || updateBasketDTO.Quantity < 1)
            {
                return BadRequest(new { Message = "Geçersiz sepet verisi." });
            }

            try
            {
                // Make the API call to update the basket quantity
                var response = await client.PutAsJsonAsync($"Baskets/{updateBasketDTO.BasketID}", new
                {
                    BasketID = updateBasketDTO.BasketID,
                    Quantity = updateBasketDTO.Quantity,
                });

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { Message = "Sepet başarıyla güncellendi." });
                }
                else
                {
                    return StatusCode(500, new { Message = "Sepet güncellenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Sunucu hatası.", ErrorDetails = ex.Message });
            }
        }
    }
}