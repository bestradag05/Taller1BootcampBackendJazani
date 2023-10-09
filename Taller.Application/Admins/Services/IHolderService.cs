using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Admins.Dtos.Holders;

namespace Taller.Application.Admins.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> findAllAsync();
        Task<HolderDto?> FindByIdAsync(int id);
        Task<HolderDto> CreateAsync(HolderSaveDto saveDto);
        Task<HolderDto> EditAsync(int id, HolderSaveDto saveDto);
        Task<HolderDto> DisabledAsync(int id);
    }
}
