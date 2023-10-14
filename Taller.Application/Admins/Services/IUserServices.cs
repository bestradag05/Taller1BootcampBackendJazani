using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Users;

namespace Taller.Application.Admins.Services
{
    public interface IUserServices 
    {
        Task<IReadOnlyList<UserDto>> findAllAsync();
        Task<UserDto?> FindByIdAsync(int id);
        Task<UserDto> CreateAsync(UserSaveDto saveDto);
        Task<UserDto> EditAsync(int id, UserSaveDto saveDto);
        Task<UserDto> DisabledAsync(int id);

        Task<UserSecurityDto> LoginAsync(UserAuthDto auth);
    }
}
