using Taller.Application.Admins.Dtos.Permissions;

namespace Taller.Application.Admins.Services
{
    public interface IPermissionServices
    {
        Task<IReadOnlyList<PermissionDto>> findAllAsync();
        Task<PermissionDto?> FindByIdAsync(int id);
        Task<PermissionDto> CreateAsync(PermissionSaveDto saveDto);
        Task<PermissionDto> EditAsync(int id, PermissionSaveDto saveDto);
        Task<PermissionDto> DisabledAsync(int id);
    }
}
