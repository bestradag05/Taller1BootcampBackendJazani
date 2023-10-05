using AutoMapper;
using Taller.Application.Admins.Dtos.Permissions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class PermisionServices : IPermissionServices
    {
        private IPermissionRepository _permissionRepository;
        private IMapper _mapper;

        public PermisionServices(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<PermissionDto> CreateAsync(PermissionSaveDto saveDto)
        {
            Permission permision = _mapper.Map<Permission>(saveDto);
            permision.RegistrationDate = DateTime.Now;
            permision.State = true;

            await _permissionRepository.SaveAsync(permision);

            return _mapper.Map<PermissionDto>(permision);
        }

        public async Task<PermissionDto> DisabledAsync(int id)
        {
            Permission permission = await _permissionRepository.FindByIdAsync(id);
            permission.State = false;

            await _permissionRepository.SaveAsync(permission);

            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<PermissionDto> EditAsync(int id, PermissionSaveDto saveDto)
        {
            Permission permission = await _permissionRepository.FindByIdAsync(id);

            _mapper.Map<PermissionSaveDto, Permission>(saveDto, permission);

            await _permissionRepository.SaveAsync(permission);

            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<IReadOnlyList<PermissionDto>> findAllAsync()
        {
            IReadOnlyList<Permission> permissions = await _permissionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PermissionDto>>(permissions);
        }

        public async Task<PermissionDto?> FindByIdAsync(int id)
        {
            Permission permimsions = await _permissionRepository.FindByIdAsync(id);

            return _mapper.Map<PermissionDto>(permimsions);
        }
    }
}
