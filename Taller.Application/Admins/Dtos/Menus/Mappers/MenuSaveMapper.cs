using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Menus.Mappers
{
    public class MenuSaveMapper : Profile
    {
        public MenuSaveMapper() {

            CreateMap<Menu, menuSaveDto>().ReverseMap();
        }
    }
}
