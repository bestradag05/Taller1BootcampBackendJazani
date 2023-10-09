using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Services
{
    public interface IMiningConcessionService
    {
        Task<IReadOnlyList<MiningConsessionDto>> FindAllAsync();

        Task<MiningConsessionDto?> FindByIdAsync(int id);
        Task<MiningConsessionDto> CreateAsync(MiningConsessionSaveDto saveDto);

        Task<MiningConsessionDto> EditAsync(int id, MiningConsessionSaveDto saveDto);

        Task<MiningConsessionDto> DiasabledAsync(int id);
    }
}
