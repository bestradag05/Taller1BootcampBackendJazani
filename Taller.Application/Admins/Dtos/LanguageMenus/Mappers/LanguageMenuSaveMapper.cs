using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.LanguageMenus.Mappers
{
    public class LanguageMenuSaveMapper : Profile
    {
        public LanguageMenuSaveMapper()
        {

            CreateMap<LanguageMenu, languageMenuSaveDto>().ReverseMap();
        }

    }
}
