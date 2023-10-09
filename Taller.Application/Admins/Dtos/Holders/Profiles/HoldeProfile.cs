using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Holders.Profiles
{
    public class HoldeProfile : Profile
    {
        public HoldeProfile() {

            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
            CreateMap<Holder, HolderSaveDto>().ReverseMap();
        }
    }
}
