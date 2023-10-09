using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Dtos.InvestmentConcepts;

namespace Taller.Application.Admins.Services
{
    public interface IInvestmentConceptService
    {
        Task<IReadOnlyList<InvestmentConceptDto>> findAllAsync();
        Task<InvestmentConceptDto?> FindByIdAsync(int id);
        Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto saveDto);
        Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto saveDto);
        Task<InvestmentConceptDto> DisabledAsync(int id);
    }
}
