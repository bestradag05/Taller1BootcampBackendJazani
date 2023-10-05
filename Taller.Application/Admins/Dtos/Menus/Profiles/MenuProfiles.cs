using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Menus.Profiles
{
    public class MenuProfiles : Profile
    {
        public MenuProfiles() {
            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, MenuSimpleDto>();
            CreateMap<Menu, MenuSaveDto>().ReverseMap();
        }
    }
}
