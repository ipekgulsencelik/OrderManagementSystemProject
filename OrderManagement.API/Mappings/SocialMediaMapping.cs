using AutoMapper;
using OrderManagement.DTO.DTOs.SocialMediaDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<ResultSocialMediaDTO, SocialMedia>().ReverseMap();
        }
    }
}