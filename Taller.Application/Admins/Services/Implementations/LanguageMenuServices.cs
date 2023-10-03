using AutoMapper;
using Taller.Application.Admins.Dtos.LanguageMenus;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class LangaugeMenuService : ILanguageMenuService
    {
        private readonly ILanguageMenuRepository _languageMenuRepository;
        private readonly IMapper _mapper;

        public LangaugeMenuService(ILanguageMenuRepository languageMenuRepository, IMapper mapper)
        {
            _languageMenuRepository = languageMenuRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LanguageMenuDto>> findAllAsync()
        {
            IReadOnlyList<LanguageMenu> languagemenus = await _languageMenuRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LanguageMenuDto>>(languagemenus);
        }

        public async Task<LanguageMenuDto?> FindByIdAsync(int id)
        {
            LanguageMenu? languagemenus = await _languageMenuRepository.FindByIdAsync(id);

            return _mapper.Map<LanguageMenuDto?>(languagemenus);
        }

        public async Task<LanguageMenuDto> CreateAsync(languageMenuSaveDto languageMenuSaveDto)
        {
            LanguageMenu languageMenu = _mapper.Map<LanguageMenu>(languageMenuSaveDto);
            languageMenu.RegistrationDate = DateTime.Now;
            languageMenu.State = true;

            LanguageMenu languageMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            return _mapper.Map<LanguageMenuDto>(languageMenuSaved);
        }


        public async Task<LanguageMenuDto> EditAsync(int id, languageMenuSaveDto languageMenuSaveDto)
        {

            LanguageMenu languageMenu = await _languageMenuRepository.FindByIdAsync(id);

            _mapper.Map<languageMenuSaveDto, LanguageMenu>(languageMenuSaveDto, languageMenu);

            LanguageMenu languageMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            return _mapper.Map<LanguageMenuDto>(languageMenuSaved);
        }


        public async Task<LanguageMenuDto> DisabledAsync(int id)
        {

            LanguageMenu languageMenu = await _languageMenuRepository.FindByIdAsync(id);
            languageMenu.State = false;



            LanguageMenu languaMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            return _mapper.Map<LanguageMenuDto>(languaMenuSaved);
        }
    }
}
