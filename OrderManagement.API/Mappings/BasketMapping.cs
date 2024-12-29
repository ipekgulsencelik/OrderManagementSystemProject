using AutoMapper;
using OrderManagement.DTO.DTOs.BasketDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<CreateBasketDTO, Basket>().ReverseMap();
            CreateMap<UpdateBasketDTO, Basket>().ReverseMap();
        }
    }
}