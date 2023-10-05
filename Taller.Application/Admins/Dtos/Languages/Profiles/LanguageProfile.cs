using AutoMapper;
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
