using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Services
{
    public interface IMeasureUnitService
    {
        Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync();

        Task<MeasureUnitDto?> FindByIdAsync(int id);
        Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto saveDto);

        Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto saveDto);

        Task<MeasureUnitDto> DiasabledAsync(int id);   
    }
}
