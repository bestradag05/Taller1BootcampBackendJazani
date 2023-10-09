using AutoMapper;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Domain.Admins.Models;


namespace Taller.Application.Admins.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile() {

            CreateMap<Investment, InvestmentDto>();

            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();
        }
    }
}
