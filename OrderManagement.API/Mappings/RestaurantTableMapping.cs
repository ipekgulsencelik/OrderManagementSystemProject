using AutoMapper;
using OrderManagement.DTO.DTOs.RestaurantTableDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class RestaurantTableMapping : Profile
    {
        public RestaurantTableMapping()
        {
            CreateMap<CreateRestaurantTableDTO, RestaurantTable>().ReverseMap();
            CreateMap<UpdateRestaurantTableDTO, RestaurantTable>().ReverseMap();
            CreateMap<ResultRestaurantTableDTO, RestaurantTable>().ReverseMap();
        }
    }
}