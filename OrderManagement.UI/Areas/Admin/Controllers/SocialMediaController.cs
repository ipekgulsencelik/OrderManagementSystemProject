﻿using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.SocialMediaDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedias");
            return View(values);
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync("SocialMedias/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            await _client.PostAsJsonAsync("SocialMedias", createSocialMediaDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSocialMediaDTO>("SocialMedias/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            await _client.PutAsJsonAsync("SocialMedias", updateSocialMediaDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("SocialMedias/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("SocialMedias/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("SocialMedias/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}