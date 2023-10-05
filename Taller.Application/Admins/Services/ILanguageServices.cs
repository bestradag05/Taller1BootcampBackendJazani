

using Taller.Application.Admins.Dtos.Languages;

namespace Taller.Application.Admins.Services
{
    public interface  ILanguageServices
    {
        Task<IReadOnlyList<LanguageDto>> findAllAsync();
        Task<LanguageDto?> FindByIdAsync(int id);
        Task<LanguageDto> CreateAsync(LanguageSaveDto languageSaveDto);
        Task<LanguageDto> EditAsync(int id, LanguageSaveDto languageSaveDto);
        Task<LanguageDto> DisabledAsync(int id);
    }
}
