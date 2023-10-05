using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuServices(IMenuRepository menuRepository , IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<MenuDto>> findAllAsync()
        {
            IReadOnlyList<Menu> menus = await _menuRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MenuDto>>(menus);
        }

        public async Task<MenuDto?> FindByIdAsync(int id)
        {
            Menu? menu = await _menuRepository.FindByIdAsync(id);

            return _mapper.Map<MenuDto?>(menu); 
        }

        public async Task<MenuDto> CreateAsync(MenuSaveDto menuSaveDto)
        {
            Menu menu = _mapper.Map<Menu>(menuSaveDto);
            menu.RegistrationDate = DateTime.Now;
            menu.State = true;

            Menu menuSaved = await _menuRepository.SaveAsync(menu);

            return _mapper.Map<MenuDto>(menuSaved);
        }


        public async Task<MenuDto> EditAsync(int id, MenuSaveDto menuSaveDto)
        {
            Menu menu = await _menuRepository.FindByIdAsync(id);

            _mapper.Map<MenuSaveDto, Menu>(menuSaveDto, menu);

            Menu menuSaved = await _menuRepository.SaveAsync(menu);

            return _mapper.Map<MenuDto>(menuSaved);
        }


        public async Task<MenuDto> DisabledAsync(int id)
        {

            Menu menu = await _menuRepository.FindByIdAsync(id);
            menu.State = false;

            

            Menu menuSaved = await _menuRepository.SaveAsync(menu);

            return _mapper.Map<MenuDto>(menuSaved);
        }
    }
}
