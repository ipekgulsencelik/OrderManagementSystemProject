using AutoMapper;
using OrderManagement.DTO.DTOs.OrderDetailDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<ResultOrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailDTO, OrderDetail>().ReverseMap();
        }
    }
}