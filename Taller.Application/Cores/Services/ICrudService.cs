using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Investments;

namespace Taller.Application.Cores.Services
{
    public interface ICrudService<TDto, TDtoSave, ID>
    {
        Task<IReadOnlyList<TDto>> findAllAsync();
        Task<TDto> FindByIdAsync(ID id);
        Task<TDto> CreateAsync(TDtoSave saveDto);
        Task<TDto> EditAsync(ID id, TDtoSave saveDto);
        Task<TDto> DisabledAsync(ID id);
    }
}
