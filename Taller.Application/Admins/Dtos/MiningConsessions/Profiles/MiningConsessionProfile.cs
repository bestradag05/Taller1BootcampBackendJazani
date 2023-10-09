using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.MiningConsessions.Profiles
{
    public class MiningConsessionProfile : Profile
    {
        public MiningConsessionProfile() {

            CreateMap<MiningConcession, MiningConsessionDto>();
            CreateMap<MiningConcession, MiningConsessionSimpleDto>();
            CreateMap<MiningConcession, MiningConsessionSaveDto>().ReverseMap();

        }
    }
}
