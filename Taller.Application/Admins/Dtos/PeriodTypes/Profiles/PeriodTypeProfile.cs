﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.PeriodTypes.Profiles
{
    public class PeriodTypeProfile : Profile
    {
        public PeriodTypeProfile() {

            CreateMap<PeriodType, PeriodTypeDto>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>();
            CreateMap<PeriodType, PeriodTypeSaveDto>().ReverseMap();
        }
    }
}