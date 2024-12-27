using AutoMapper;
using OrderManagement.DTO.DTOs.OrderDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<ResultOrderDTO, Order>().ReverseMap();
            CreateMap<CreateOrderDTO, Order>().ReverseMap();
            CreateMap<UpdateOrderDTO, Order>().ReverseMap();
        }
    }
}