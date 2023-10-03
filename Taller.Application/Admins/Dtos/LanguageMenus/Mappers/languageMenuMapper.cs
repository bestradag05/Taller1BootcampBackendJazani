using AutoMapper;

using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.LanguageMenus.Mappers
{
    public class languageMenuMapper : Profile
    {
        public languageMenuMapper()
        {

            CreateMap<LanguageMenu, LanguageMenuDto>();

        }
    }
}
