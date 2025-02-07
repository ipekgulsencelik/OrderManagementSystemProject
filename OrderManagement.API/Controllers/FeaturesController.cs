﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.FeatureDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMapper _mapper, IFeatureService _featureService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _featureService.TGetList();
            var result = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(result);
        }

        [HttpGet("GetLast3Features")]
        public IActionResult GetLast3Features()
        {
            var values = _featureService.TGetLast3Features();
            var features = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(features);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _featureService.TDelete(id);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDTO createFeatureDTO)
        {
            var newValue = _mapper.Map<Feature>(createFeatureDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _featureService.TCreate(newValue);
            return Ok("Yeni Öne Çıkan Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _featureService.TUpdate(value);
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("GetActiveFeatures")]
        public IActionResult GetActiveFeatures()
        {
            var values = _featureService.TGetFilteredList(x => x.Status == true);
            var actives = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassiveFeatures")]
        public IActionResult GetPassiveFeatures()
        {
            var values = _featureService.TGetFilteredList(x => x.Status == false);
            var passives = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(passives);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _featureService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _featureService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _featureService.TChangeStatus(id);
            return Ok("Durum Değiştirildi.");
        }
    }
}