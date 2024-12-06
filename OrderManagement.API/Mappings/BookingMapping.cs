using AutoMapper;
using OrderManagement.DTO.DTOs.BookingDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<UpdateBookingDTO, Booking>().ReverseMap();
            CreateMap<ResultBookingDTO, Booking>().ReverseMap();
        }
    }
}