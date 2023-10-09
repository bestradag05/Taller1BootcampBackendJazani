using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.InvestmentConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile() {

            CreateMap<InvestmentConcept, InvestmentConceptDto>();
            CreateMap<InvestmentConcept, InvesmentConceptSimpleDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSaveDto>().ReverseMap();
        }
    }
}
