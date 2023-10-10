using AutoMapper;
using Taller.Core.Paginations;
using Taller.Domain.Admins.Models;


namespace Taller.Application.Admins.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile() {

            CreateMap<Investment, InvestmentDto>();
            CreateMap<Investment, InvestmentDto>().ReverseMap();

            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

            CreateMap<Investment, InvestmentFilterDto>().ReverseMap();

            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>().ReverseMap();

        }
    }
}
