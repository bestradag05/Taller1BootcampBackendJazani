using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Application.Admins.Dtos.PeriodTypes;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Services
{
    public interface IPeriodTypeService
    {
        Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync();

        Task<PeriodTypeDto?> FindByIdAsync(int id);
        Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto saveDto);

        Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto saveDto);

        Task<PeriodTypeDto> DiasabledAsync(int id);
    }
}
