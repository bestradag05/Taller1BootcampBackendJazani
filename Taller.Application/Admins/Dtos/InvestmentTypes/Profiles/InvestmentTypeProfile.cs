using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile() {

            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();
            CreateMap<InvestmentType, InvestmentTypeSaveDto>().ReverseMap();
        }  
    }
}
