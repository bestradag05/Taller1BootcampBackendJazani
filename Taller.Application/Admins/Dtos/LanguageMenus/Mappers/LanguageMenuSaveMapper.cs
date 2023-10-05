using AutoMapper;
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
