
using Taller.Application.Admins.Dtos.Menus;

namespace Taller.Application.Admins.Services
{
    public interface IMenuService
    {
        Task<IReadOnlyList<MenuDto>> findAllAsync();
        Task<MenuDto?> FindByIdAsync(int id);
        Task<MenuDto> CreateAsync(menuSaveDto menuSaveDto);
        Task<MenuDto> EditAsync(int id, menuSaveDto officeSaveDto);
        Task<MenuDto> DisabledAsync(int id);

    }
}
