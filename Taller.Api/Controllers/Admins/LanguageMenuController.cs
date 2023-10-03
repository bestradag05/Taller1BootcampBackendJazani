using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.LanguageMenus;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageMenuController : ControllerBase
    {
        private readonly ILanguageMenuService _languageMenuService;

        public LanguageMenuController(ILanguageMenuService languageMenuService)
        {
            _languageMenuService = languageMenuService;
        }



        // GET: api/<LanguageMenuController>
        [HttpGet]
        public async Task<IEnumerable<LanguageMenuDto>> Get()
        {
            return await _languageMenuService.findAllAsync();
        }

        // GET api/<LanguageMenuController>/5
        [HttpGet("{id}")]
        public async Task<LanguageMenuDto> Get(int id)
        {
            return await _languageMenuService.FindByIdAsync(id);
        }

        // POST api/<LanguageMenuController>
        [HttpPost]
        public async Task<LanguageMenuDto> Post([FromBody] languageMenuSaveDto languageMenuSaveDto)
        {
            return await _languageMenuService.CreateAsync(languageMenuSaveDto);
        }

        // PUT api/<LanguageMenuController>/5
        [HttpPut("{id}")]
        public async Task<LanguageMenuDto> Put(int id, [FromBody] languageMenuSaveDto languageMenuSaveDto)
        {
            return await _languageMenuService.EditAsync(id, languageMenuSaveDto);
        }

        // DELETE api/<LanguageMenuController>/5
        [HttpDelete("{id}")]
        public async Task<LanguageMenuDto> Delete(int id)
        {
            return await _languageMenuService.DisabledAsync(id);
        }
    }
}
