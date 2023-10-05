using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Languages.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile() {
            CreateMap<Language, LanguageDto>();
            CreateMap<Language, LanguageSimpleDto>();
            CreateMap<Language, LanguageSaveDto>().ReverseMap();
        }    
    }
}
