using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.LanguageMenus;

namespace Taller.Application.Admins.Services
{
    public interface ILanguageMenuServices
    {
        Task<IReadOnlyList<LanguageMenuDto>> findAllAsync();
        Task<LanguageMenuDto?> FindByIdAsync(int id);
        Task<LanguageMenuDto> CreateAsync(languageMenuSaveDto languageMenuSaveDto);
        Task<LanguageMenuDto> EditAsync(int id, languageMenuSaveDto languageMenuSaveDto);
        Task<LanguageMenuDto> DisabledAsync(int id);
    }
}
