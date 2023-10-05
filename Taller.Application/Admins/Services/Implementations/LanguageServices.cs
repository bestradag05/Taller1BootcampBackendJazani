using AutoMapper;
using Taller.Application.Admins.Dtos.Languages;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class LanguageServices : ILanguageServices
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageServices(ILanguageRepository languageRepository, IMapper mapper)
        {
            this._languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageDto> CreateAsync(LanguageSaveDto languageSaveDto)
        {
            Language language = _mapper.Map<Language>(languageSaveDto);
            language.RegistrationDate = DateTime.Now;
            language.State = true;

            await _languageRepository.SaveAsync(language);

            return _mapper.Map<LanguageDto>(language);
        }

        public async Task<LanguageDto> DisabledAsync(int id)
        {
            Language language = await _languageRepository.FindByIdAsync(id);
            language.State = false;

            await _languageRepository.SaveAsync(language);

            return _mapper.Map<LanguageDto>(language);
        }

        public async Task<LanguageDto> EditAsync(int id, LanguageSaveDto languageSaveDto)
        {
            Language language = await _languageRepository.FindByIdAsync(id);

            _mapper.Map<LanguageSaveDto, Language>(languageSaveDto, language);

            await _languageRepository.SaveAsync(language);

            return _mapper.Map<LanguageDto>(language);
        }

        public async Task<IReadOnlyList<LanguageDto>> findAllAsync()
        {
            IReadOnlyList<Language> languages = await _languageRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LanguageDto>>(languages);
        }

        public async Task<LanguageDto?> FindByIdAsync(int id)
        {
            Language languages = await _languageRepository.FindByIdAsync(id);

            return _mapper.Map<LanguageDto>(languages);
        }
    }
}
