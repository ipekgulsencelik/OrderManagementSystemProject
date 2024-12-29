using AutoMapper;
using OrderManagement.DTO.DTOs.CashBoxDTOs;
using OrderManagement.Entity.Entitles;

namespace CashBoxManagement.API.Mappings
{
    public class CashBoxMapping : Profile
    {
        public CashBoxMapping()
        {
            CreateMap<ResultCashBoxDTO, CashBox>().ReverseMap();
            CreateMap<CreateCashBoxDTO, CashBox>().ReverseMap();
            CreateMap<UpdateCashBoxDTO, CashBox>().ReverseMap();
        }
    }
}