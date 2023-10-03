using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService )
        {
            _menuService = menuService;
        }


        // GET: api/<MenuController>
        [HttpGet]
        public async Task<IEnumerable<MenuDto>> Get()
        {
            return await _menuService.findAllAsync();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<MenuDto> Get(int id)
        {
            return await _menuService.FindByIdAsync(id);
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<MenuDto> Post([FromBody] menuSaveDto menuSaveDto)
        {
            return await _menuService.CreateAsync(menuSaveDto);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public async Task<MenuDto> Put(int id, [FromBody] menuSaveDto menuSaveDto)
        {

            return await _menuService.EditAsync(id, menuSaveDto);
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public async Task<MenuDto> Delete(int id)
        {
            return await _menuService.DisabledAsync(id);
        }
    }
}
