using AutoMapper;
using OrderManagement.DTO.DTOs.NotificationDTOs;
using OrderManagement.Entity.Entitles;

namespace NotificationManagement.API.Mappings
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<CreateNotificationDTO, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDTO, Notification>().ReverseMap();
        }
    }
}