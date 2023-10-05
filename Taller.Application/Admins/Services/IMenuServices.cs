
using Taller.Application.Admins.Dtos.Menus;

namespace Taller.Application.Admins.Services
{
    public interface IMenuServices
    {
        Task<IReadOnlyList<MenuDto>> findAllAsync();
        Task<MenuDto?> FindByIdAsync(int id);
        Task<MenuDto> CreateAsync(MenuSaveDto menuSaveDto);
        Task<MenuDto> EditAsync(int id, MenuSaveDto officeSaveDto);
        Task<MenuDto> DisabledAsync(int id);

    }
}
