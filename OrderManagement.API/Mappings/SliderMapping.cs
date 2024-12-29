using AutoMapper;
using OrderManagement.DTO.DTOs.SliderDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<CreateSliderDTO, Slider>().ReverseMap();
            CreateMap<UpdateSliderDTO, Slider>().ReverseMap();
            CreateMap<ResultSliderDTO, Slider>().ReverseMap();
        }
    }
}