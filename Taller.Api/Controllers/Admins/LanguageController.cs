using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.Languages;
using Taller.Application.Admins.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageServices _languageService;

        public LanguageController(ILanguageServices languageService)
        {
            _languageService = languageService;
        }

        // GET: api/<MineralTypeController>
        [HttpGet]
        public async Task<IEnumerable<LanguageDto>> Get()
        {

            return await _languageService.findAllAsync();
        }

        // GET api/<MineralTypeController>/5
        [HttpGet("{id}")]
        public async Task<LanguageDto> Get(int id)
        {
            return await _languageService.FindByIdAsync(id);
        }

        // POST api/<MineralTypeController>
        [HttpPost]
        public async Task<LanguageDto> Post([FromBody] LanguageSaveDto saveDto)
        {
            return await _languageService.CreateAsync(saveDto);
        }

        // PUT api/<MineralTypeController>/5
        [HttpPut("{id}")]
        public async Task<LanguageDto> Put(int id, [FromBody] LanguageSaveDto saveDto)
        {
            return await _languageService.EditAsync(id, saveDto);
        }

        // DELETE api/<MineralTypeController>/5
        [HttpDelete("{id}")]
        public async Task<LanguageDto> Delete(int id)
        {
            return await _languageService.DisabledAsync(id);
        }
    }
}
