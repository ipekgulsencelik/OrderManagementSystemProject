using AutoMapper;
using OrderManagement.DTO.DTOs.FeatureDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Mappings
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<CreateFeatureDTO, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDTO, Feature>().ReverseMap();
            CreateMap<ResultFeatureDTO, Feature>().ReverseMap();
        }
    }
}