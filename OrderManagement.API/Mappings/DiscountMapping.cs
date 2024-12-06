using AutoMapper;
using OrderManagement.DTO.DTOs.DiscountDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateDiscountDTO, Discount>().ReverseMap();
            CreateMap<UpdateDiscountDTO, Discount>().ReverseMap();
            CreateMap<ResultDiscountDTO, Discount>().ReverseMap();
        }
    }
}